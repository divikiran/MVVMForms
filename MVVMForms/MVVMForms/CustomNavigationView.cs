using System;
using Xamarin.Forms;

namespace MVVMForms
{
    public class CustomNavigationView : NavigationPage
    {
        public static Color TabBarBackgroundColor
        {
            get;
            set;
        } = Color.White;
        public static Color TitleTextColor { get; set; }

        public CustomNavigationView(Page root) : base(root)
        {
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BarBackgroundColor = TabBarBackgroundColor;
            this.BarTextColor = TitleTextColor;
        }
    }
}
