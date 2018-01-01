using System;
using System.Threading.Tasks;

namespace MVVMForms
{
    public interface INavigationService
    {
        BasePageModel PreviousPageViewModel { get; }

        //Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : BasePageModel;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BasePageModel;

        Task RemoveLastFromBackStackAsync();

        Task RemoveBackStackAsync();
    }
}
