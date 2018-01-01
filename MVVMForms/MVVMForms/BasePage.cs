using System;
using Xamarin.Forms;

namespace MVVMForms
{
    public class BasePage : ContentPage
    {
        public BasePageModel BasePageModel
        {
            get;
            set;
        }

        public BasePage()
        {
            Title = string.Empty;
            IsBusy = false;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext != null && BindingContext is BasePageModel)
            {
                BasePageModel = (BasePageModel)BindingContext;
                BasePageModel.CurrentPage = this;
                BasePageModel.Navigation = this.Navigation;

                SetPageProperties();

                await BasePageModel?.OnAppearing();
            }
        }

        private void SetPageProperties()
        {
            this.SetBinding(TitleProperty, nameof(BasePageModel.Title));
            this.SetBinding(IsBusyProperty, nameof(BasePageModel.IsBusy));
        }

        protected async override void OnDisappearing()
        {
            base.OnDisappearing();
            if (BindingContext != null && BindingContext is BasePageModel)
            {
                BasePageModel = (BasePageModel)BindingContext;
                BasePageModel.CurrentPage = this;
                BasePageModel.Navigation = this.Navigation;
                await BasePageModel?.OnDisappearing();
            }
        }
    }
}
