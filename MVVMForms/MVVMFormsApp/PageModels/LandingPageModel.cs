using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMForms;
using MVVMFormsApp.Data.Entities;
using MVVMFormsApp.Data.Repositories.PersonRepository;
using MVVMFormsApp.PageViewModels;
using MVVMFormsApp.Validations;
using Xamarin.Forms;

namespace MVVMFormsApp.PageModels
{
    public class LandingPageModel : BasePageModel
    {
        ValidatableObject<string> _name = new ValidatableObject<string>();
        public ValidatableObject<string> Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        List<ProductViewModel> products;
        public List<ProductViewModel> Products
        {
            get
            {
                return products;
            }

            set
            {
                products = value;
                RaisePropertyChanged();
            }
        }

        bool _enableClickMeButton;
        public bool EnableClickMeButton
        {
            get
            {
                return _enableClickMeButton;
            }

            set
            {
                _enableClickMeButton = value;
                RaisePropertyChanged();
            }
        }

        ICommand _saveName;
        public ICommand SaveName
        {
            get
            {
                return _saveName ?? new Command(async () => await SaveToNamesTable(), () =>
                {
                    EnableClickMeButton = false;
                    if (Name.Validate())
                    {
                        EnableClickMeButton = true;

                    }
                    return EnableClickMeButton;
                });
            }
        }

        ICommand _navigateToDetailPage;
        public ICommand NavigateToDetailPage
        {
            get
            {
                return _navigateToDetailPage ?? new Command(async (obj) => await GoToNavigateToPage(obj));
            }
        }

        private async Task GoToNavigateToPage(object selectedItem)
        {
            var item = selectedItem as SelectedItemChangedEventArgs;
            if (item == null)
                return;

            var product = item.SelectedItem as ProductViewModel;
            if (product == null)
                return;

            //await this._navigationService.NavigateToAsync<DetailsPageModel>(product);
            await this._navigationService.NavigateToAsync<ProductDetailsPageModel>(product);

        }

        ICommand validateNameCommand;
        public ICommand ValidateNameCommand
        {
            get
            {
                return validateNameCommand ?? new Command(async (object obj) => await ValidateName());
            }
        }

        private Task<bool> ValidateName()
        {
            var isValid = EnableClickMeButton = _name.Validate();
            if (isValid)
            {
                SaveName.CanExecute(null);
            }
            return Task.Run(() => isValid);
        }

        IPersonRepository _personRepository;
        INavigationService _navigationService;

        public LandingPageModel(IPersonRepository personRepository, INavigationService iNavigationService)
        {
            this._navigationService = iNavigationService;
            this._personRepository = personRepository;
            Title = "Home";
            AddValidations();

            Products = new List<ProductViewModel>();
            }


        private async Task SaveToNamesTable()
        {
            var person = new PersonEntity()
            {
                Name = this.Name.Value
            };
            await _personRepository.Insert(person);
            await LoadNames();
        }

        public async override Task OnAppearing()
        {
            //await LoadNames();
            ProductViewModel bellBrandRice = new ProductViewModel() { Name="Bell Rice", Price = "From $40.00", ImageUrl = "https://i.ytimg.com/vi/zUpEa3ITgFo/maxresdefault.jpg" };

            ProductViewModel lalithaBrandRice = new ProductViewModel() { Name="Lalitha Rice", Price = "From $45.00", ImageUrl = "https://i.ytimg.com/vi/0ee7A6pZXMc/maxresdefault.jpg" };


            var ps = new List<ProductViewModel>();

            ps.Add(bellBrandRice);
            ps.Add(lalithaBrandRice);
            Products = ps;
                
        
        }

        private async Task LoadNames()
        {
            var persons = await _personRepository.GetAll();
            //this.Names = persons?.Select(s => s.Name)?.ToList();
        }

        private void AddValidations()
        {
            _name.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Name is required." });
        }
    }
}
