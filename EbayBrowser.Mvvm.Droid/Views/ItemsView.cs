using System;
using Android.App;
using EbayBrowser.Mvvm.Shared.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;

namespace EbayBrowser.Mvvm.Droid.Views
{
    [Activity(MainLauncher = true)]
    public class ItemsView : MvxActivity<ItemsViewModel>
    {
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.ItemsView);
            //Bindings
            var bindings = this.CreateBindingSet<ItemsView, ItemsViewModel>();
            bindings.Bind(this).For(s => s.Title).To(vm => vm.PageTitle);
            bindings.Apply();
        }
    }
}
