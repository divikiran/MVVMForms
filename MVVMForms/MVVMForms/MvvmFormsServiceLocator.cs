using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Unity;
using Xamarin.Forms;
using Unity.RegistrationByConvention;
using System.Linq;

namespace MVVMForms
{
    public static class MvvmFormsServiceLocator
    {
        public static UnityContainer Container;

        static MvvmFormsServiceLocator()
        {
        }

        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(MvvmFormsServiceLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(MvvmFormsServiceLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(MvvmFormsServiceLocator.AutoWireViewModelProperty, value);
        }

        public static bool UseMockService { get; set; }

        public static void Build()
        {
            Container.RegisterType<INavigationService, NavigationService>();
        }

        //public static void Build(bool useMockServices = false)
        //{
        //    var builder = new UnityContainer();
        //    if (RegisterViewmodels?.Count() > 0)
        //    {
        //        foreach (Type vm in RegisterViewmodels)
        //        {
        //            builder.RegisterType(vm);
        //        }
        //    }

        //    if (Registraions?.Count() > 0)
        //    {
        //        foreach (Tuple<Type, Type> item in Registraions)
        //        {
        //            builder.RegisterType(item.Item1, item.Item2);
        //        }
        //    }

        //    if (Container != null)
        //    {
        //        Container.Dispose();
        //    }
        //    Container = builder;


        //    //View models
        //    //builder.RegisterType<LoginViewModel>();
        //    //builder.RegisterType<MainViewModel>();
        //    //builder.RegisterType<LandingViewModel>();
        //    //builder.RegisterType<SettingsViewModel>();



        //    // Services
        //    //builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
        //    //builder.RegisterType<DialogService>().As<IDialogService>();
        //    //builder.RegisterType<RequestProvider>().As<IRequestProvider>();
        //    //builder.RegisterType<LocationService>().As<ILocationService>().SingleInstance();
        //    //builder.RegisterType<PersonRepository>().As<IPersonRepository>().SingleInstance();
        //    //builder.RegisterType<RequestProvider>().As<IRequestProvider>().SingleInstance();


           
        //}

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Pages.", ".PageModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }
            var viewModel = Container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}
