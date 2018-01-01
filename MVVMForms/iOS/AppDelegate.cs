using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using SVG.Forms.Plugin.iOS;
using UIKit;

namespace MVVMFormsApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            SvgImageRenderer.Init();
            // Code for starting up the Xamarin Test Cloud Agent
#if DEBUG
			Xamarin.Calabash.Start();
#endif
            App.ScreenHeight = (int)UIScreen.MainScreen.Bounds.Height;
            App.ScreenWidth = (int)UIScreen.MainScreen.Bounds.Width;
            LoadApplication(new App());
            //UINavigationBar.Appearance.BackgroundColor = UIColor.FromRGB(0, 154, 78);
            //UITabBar.Appearance.BackgroundColor = UIColor.FromRGB(0, 154, 78);
            UITabBar.Appearance.SelectedImageTintColor = UIColor.White;// UIColor.FromRGB(0, 0, 0);
            //UITabBar.Appearance.TintColor = UIColor.FromRGB(0,154,78);
            return base.FinishedLaunching(app, options);
        }
    }
}
