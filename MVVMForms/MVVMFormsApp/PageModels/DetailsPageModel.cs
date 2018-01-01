using System;
using System.Threading.Tasks;
using MVVMForms;
using MVVMFormsApp.PageViewModels;

namespace MVVMFormsApp.PageModels
{
    public class DetailsPageModel : BasePageModel
    {
        string _description;

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
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

        ProductViewModel _product;
        public ProductViewModel Product
        {
            get
            {
                return _product;
            }

            set
            {
                _product = value;
                RaisePropertyChanged();
            }
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await base.InitializeAsync(navigationData);
            Product = (ProductViewModel)navigationData;
            Description = Product.Description;
            Title = Product.Name;
            ImageUrl = Product.ImageUrl;
        }

        public DetailsPageModel()
        {
            //Title = "Product Details";
        }
    }
}
