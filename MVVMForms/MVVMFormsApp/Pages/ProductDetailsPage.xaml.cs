using System;
using System.Collections.Generic;
using MVVMForms;
using Xamarin.Forms;

namespace MVVMFormsApp.Pages
{
    public partial class ProductDetailsPage : BasePage
    {
        public ProductDetailsPage()
        {
            InitializeComponent();
            var height = App.ScreenHeight;
            //ProductScrollView.HeightRequest = 100;// height * 0.7;
        }
    }
}
