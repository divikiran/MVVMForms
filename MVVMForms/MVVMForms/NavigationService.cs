using System;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVMForms
{
    public class NavigationService : INavigationService 
    {
        public BasePageModel PreviousPageViewModel
        {
            get
            {
                var mainPage = Application.Current.MainPage as CustomNavigationView;
                var viewModel = mainPage?.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2].BindingContext; //hard coded number?
                return viewModel as BasePageModel;
            }
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BasePageModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BasePageModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task RemoveLastFromBackStackAsync()
        {
            if (Application.Current.MainPage is CustomNavigationView mainPage)
            {
                mainPage.Navigation.RemovePage(
                    mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
            }

            return Task.FromResult(true);
        }

        public Task RemoveBackStackAsync()
        {
            if (Application.Current.MainPage is CustomNavigationView mainPage)
            {
                for (int i = 0; i < mainPage.Navigation.NavigationStack.Count - 1; i++)
                {
                    var page = mainPage.Navigation.NavigationStack[i];
                    mainPage.Navigation.RemovePage(page);
                }
            }

            return Task.FromResult(true);
        }

        private async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreatePage(viewModelType, parameter);

            if(page is TabbedPage)
            {
                Application.Current.MainPage = page;
            }
            else if (page is ContentPage np)
            {
                //await Application.Current.MainPage.Navigation.PushAsync(np);
                //await np.Navigation.PushAsync(page);
                //await np.PushAsync(page);
                //await Application.Current.MainPage.Navigation.PushAsync(page);
            }
            else if (Application.Current.MainPage is CustomNavigationView navigationPage)
            {
                await navigationPage.PushAsync(page);
                //await Application.Current.MainPage.Navigation.PushAsync(page);
            }
            else
            {
                Application.Current.MainPage = new CustomNavigationView(page);
            }


            await (page.BindingContext as BasePageModel)?.InitializeAsync(parameter);
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }
    }
}