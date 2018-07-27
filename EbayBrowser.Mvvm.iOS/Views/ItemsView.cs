using System;
using EbayBrowser.Mvvm.Shared.ViewModels;
using EbayBrowser.Mvvm.iOS.Controls;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Views;
using UIKit;
using EbayBrowser.Services.Models;

namespace EbayBrowser.Mvvm.iOS.Views
{
    public class ItemsView : MvxTableViewController<ItemsViewModel>
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            DataSource ds = new DataSource(TableView, UITableViewCellStyle.Default, new NSString("cellId"), nameof(ItemViewCell.Title) + " " + nameof(Item.Title) + ";" + nameof(ItemViewCell.Price) + " " + nameof(Item.ConvertedCurrentPrice) + ",Converter=Price;" + nameof(ItemViewCell.GalleryImageUrl) + " " + nameof(Item.GalleryURL));
            TableView.Source = ds;
            //Bindings
            var bindings = this.CreateBindingSet<ItemsView, ItemsViewModel>();
            bindings.Bind(this).For(s => s.Title).To(vm => vm.PageTitle);
            bindings.Bind(ds).To(vm => vm.Rows);
            bindings.Apply();
        }
    }

    class DataSource : MvxStandardTableViewSource
    {
        private const int DEFAULT_ROW_HEIGHT = 44;

        public DataSource(UITableView tableView, UITableViewCellStyle tableCellStyle, NSString cellId, string bindingText, UITableViewCellAccessory cellAccessory = UITableViewCellAccessory.None) : base(tableView, tableCellStyle, cellId, bindingText, cellAccessory)
        {
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return (DEFAULT_ROW_HEIGHT * 3);
        }

        protected override MvxStandardTableViewCell CreateDefaultBindableCell(UITableView tableView, NSIndexPath indexPath, object item)
        {
            ItemViewCell retVal = new ItemViewCell(BindingDescriptions, CellIdentifier);
            return (retVal);
        }
    }
}
