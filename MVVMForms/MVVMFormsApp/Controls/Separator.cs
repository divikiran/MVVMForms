using System;
using Xamarin.Forms;

namespace MVVMFormsApp.Controls
{
    public class Separator : StackLayout
    {
        public Separator()
        {
            BackgroundColor = Color.FromHex("#B3C3D0");
            //Padding = 1;
            HeightRequest = 3;
        }
    }
}
