using System;
using MVVMForms;

namespace MVVMFormsApp.PageViewModels
{
    public class ProductViewModel : BasePageModel
    {
        string _name;
        public string Name
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

        string _price;
        public string Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
                RaisePropertyChanged();
            }
        }

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

        int _id;
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
                RaisePropertyChanged();
            }
        }

        int _cartCount;
        public int CartCount
        {
            get
            {
                return _cartCount;
            }

            set
            {
                _cartCount = value;
                RaisePropertyChanged();
            }
        }

        bool _isFavorite;
        public bool IsFavorite
        {
            get
            {
                return _isFavorite;
            }

            set
            {
                _isFavorite = value;
                RaisePropertyChanged();
            }
        }
    }
}