using System;
using MVVMForms;
using MVVMFormsApp.Data.Connection;
using MVVMFormsApp.Data.Repositories.PersonRepository;
using MVVMFormsApp.PageModels;
using MVVMFormsApp.Pages;
using Xamarin.Forms;
using Unity;
using System.Threading.Tasks;

namespace MVVMFormsApp
{
    public partial class App : Application
    {
        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }

        public App()
        {
            InitializeComponent();

            MvvmFormsServiceLocator.Container = new UnityContainer();

            MvvmFormsServiceLocator.Container.RegisterType<IPersonRepository, PersonRepository>();

            //MvvmFormsServiceLocator.Container.RegisterType<LandingPage>();

            MvvmFormsServiceLocator.Container.RegisterType<LandingPageModel>();
            MvvmFormsServiceLocator.Container.RegisterType<DetailsPageModel>();

            MvvmFormsServiceLocator.Build();

            //Give db name
            DbConnect.Instance.DbName = "Testdb";
            DbConnect.Instance.BuildDb();

            InitNavigation();


            //Set Main page
            //MainPage = new CustomNavigationView(MvvmFormsServiceLocator.Container.Resolve<LandingPage>());



        }

        private Task InitNavigation()
        {
            CustomNavigationView.TabBarBackgroundColor = Color.FromHex("#EE3C42");
            CustomNavigationView.TitleTextColor = Color.White;
            var navigationService = MvvmFormsServiceLocator.Resolve<INavigationService>();
            return navigationService.NavigateToAsync<HomeTabbedPageModel>(); //.InitializeAsync();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
