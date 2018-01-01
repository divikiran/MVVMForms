using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVMForms
{
    public class BasePageModel : ExtendedBindableObject
    {
        public BasePage CurrentPage { get; internal set; }
        public INavigation Navigation { get; internal set; }

        string _title;
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                RaisePropertyChanged();
            }
        }

        public async virtual Task OnAppearing() { }
        public async virtual Task OnDisappearing() { }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

    }
}
