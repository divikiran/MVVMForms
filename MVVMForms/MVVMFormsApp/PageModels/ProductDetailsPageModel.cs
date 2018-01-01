using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMForms;
using MVVMFormsApp.PageViewModels;
using Xamarin.Forms;

namespace MVVMFormsApp.PageModels
{
    public class ProductDetailsPageModel : BasePageModel
    {
        int deviceHeight;
        public int DeviceHeight
        {
            get
            {
                return deviceHeight;
            }

            set
            {
                deviceHeight = value;
                RaisePropertyChanged();
            }
        }

        string _imageUrl;
        public string ImageUrl
        {
            get
            {
                return _imageUrl;
            }

            set
            {
                _imageUrl = value;
                RaisePropertyChanged();
            }
        }

        List<ProductViewModel> _products;
        public List<ProductViewModel> Products
        {
            get
            {
                return _products;
            }

            set
            {
                _products = value;
                RaisePropertyChanged();
            }
        }

        readonly INavigationService _navigationService;

        public ProductDetailsPageModel(INavigationService iNavigationService)
        {
            this._navigationService = iNavigationService;
        }

        public override Task OnAppearing()
        {
            DeviceHeight = 200;// (int)(App.ScreenHeight * 0.7);
            var products = new List<ProductViewModel>();

           // ImageUrl = "https://i.ytimg.com/vi/zUpEa3ITgFo/maxresdefault.jpg";
            var product = new ProductViewModel()
            {
                Id = 1,
                ImageUrl = "https://sc01.alicdn.com/kf/HTB1Q8HUKFXXXXXTXXXXq6xXFXXX1/China-basmati-rice-40kg-bags-or-wpp.jpg",
                Name = "Godawari Super",
                Description = "Godawari Super Premium Sona Rice 1",
                Price = "$35.00",

            };

            var product1 = new ProductViewModel()
            {
                Id = 2,
                ImageUrl = "http://www.freedomcart.com/image/cache/catalog/data/Products/lalitha-brand-rice-25kg-700x700.jpg",
                Name = "Lalitha Premium",
                Description = "Lalitha Premium Sona Rice 2",
                Price = "$35.00",
            };

            var product2 = new ProductViewModel()
            {
                Id = 3,
                ImageUrl = "https://pimg.tradeindia.com/00679456/b/2/PP-Non-Woven-Rice-Bag.jpg",
                Name = "Bell Premium",
                Description = "Godawari Super Premium Sona Rice 3",
                Price = "$35.00",
            };

            var product3 = new ProductViewModel()
            {
                Id = 4,
                ImageUrl = "https://4.imimg.com/data4/PG/DF/MY-20704244/_mg_7134-250x250.jpg",
                Name = "AAR Gold Premium",
                Description = "AAR Gold Premium Sona Rice 4",
                Price = "$35.00",
            };



            products.Add(product);
            products.Add(product1);
            products.Add(product2);
            products.Add(product3); 

            Products = products;
            return base.OnAppearing();
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await base.InitializeAsync(navigationData);
            var Product = (ProductViewModel)navigationData;
            Title = Product.Name;
            ImageUrl = Product.ImageUrl;
        }

        ICommand _productCommand;
        public ICommand ProductCommand
        {
            get
            {
                return _productCommand ?? new Command(async (obj) => await GoToDetails(obj));
            }


        }

        private  async Task GoToDetails(object selectedItem)
        {
            var product = selectedItem as ProductViewModel;
            if (product == null)
                return;

            await this._navigationService.NavigateToAsync<DetailsPageModel>(product);
        }

        ICommand _addToCartCommand;
        public ICommand AddToCartCommand
        {
            get
            {
                return _addToCartCommand ?? new Command(async (object obj) => { await AddToCart(obj); });
            }
        }

        private async Task AddToCart(object obj)
        {
            var selectedProduct = obj as ProductViewModel;
            if (selectedProduct == null)
                return;

            await Task.Run(() =>
            {
                var productFound = Products.FirstOrDefault(w => w.Id == selectedProduct.Id);
                productFound.CartCount += 1;
            });

            
        }

        ICommand _removeFromCartCommand;
        public ICommand RemoveFromCartCommand
        {
            get
            {
                return _removeFromCartCommand ?? new Command(async (object obj) => { await RemoveFromCart(obj); });
            }
        }

        private async Task RemoveFromCart(object obj)
        {
            var selectedProduct = obj as ProductViewModel;
            if (selectedProduct == null)
                return;

            await Task.Run(() =>
            {
                var productFound = Products.FirstOrDefault(w => w.Id == selectedProduct.Id);
                if (productFound == null)
                    return;

                if (productFound.CartCount > 0)
                {
                    productFound.CartCount -= 1;
                }
            });
        }

        ICommand _makeFavoriteCommand;
        public ICommand MakeFavoriteCommand
        {
            get
            {
                return _makeFavoriteCommand ?? new Command(async (obj) => { await MakeFavoriteAction(obj); });
            }
        }

        private async Task MakeFavoriteAction(object obj)
        {
            var selectedProduct = obj as ProductViewModel;
            if (selectedProduct == null)
                return;

            await Task.Run(() =>
            {
            var productFound = Products.FirstOrDefault(w => w.Id == selectedProduct.Id);
                if (productFound == null)
                    return;
                
                productFound.IsFavorite = !productFound.IsFavorite;

            });
        }
    }
}
