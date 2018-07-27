using System;
using EbayBrowser.Mvvm.Shared.ViewModels;
using EbayBrowser.Services.Models;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Views;
using UIKit;

namespace EbayBrowser.Mvvm.iOS.Views
{
    public class CategoriesView : MvxTableViewController<CategoriesViewModel>
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavigationItem.BackBarButtonItem = new UIBarButtonItem("Back", UIBarButtonItemStyle.Plain, null);
            MvxStandardTableViewSource ds = new MvxStandardTableViewSource(TableView, UITableViewCellStyle.Default, new NSString("cellId"), nameof(MvxStandardTableViewCell.TitleText) + " " + nameof(Category.CategoryName), UITableViewCellAccessory.DisclosureIndicator);
            TableView.Source = ds;
            //Bindings
            var bindings = this.CreateBindingSet<CategoriesView, CategoriesViewModel>();
            bindings.Bind(this).For(s => s.Title).To(vm => vm.PageTitle);
            bindings.Bind(ds).To(vm => vm.Rows);
            bindings.Bind(ds).For(s => s.SelectionChangedCommand).To(vm => vm.ItemSelectedCommand);
            bindings.Apply();
        }
    }
}
