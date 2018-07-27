using System;
using EbayBrowser.Mvvm.Shared.ViewModels;
using EbayBrowser.Services;
using EbayBrowser.Services.Models;
using MvvmCross.IoC;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace EbayBrowser.Mvvm.Shared
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            typeof(IEbayService).Assembly.CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            RegisterCustomAppStart<CustomAppStart>();
        }

        //Create custom app start to allow pass null parent Category to first view model
        class CustomAppStart : MvxAppStart
        {
            public CustomAppStart(IMvxApplication application, IMvxNavigationService navService) : base(application, navService)
            {
            }

            protected override void NavigateToFirstViewModel(object hint)
            {
                NavigationService.Navigate<CategoriesViewModel, Category>((Category)null);
            }
        }
    }
}
