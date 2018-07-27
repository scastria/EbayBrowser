using EbayBrowser.Forms.Shared.Controls;
using EbayBrowser.Forms.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CategoryCell), typeof(CategoryCellRenderer))]
namespace EbayBrowser.Forms.iOS.Renderers
{
	public class CategoryCellRenderer : TextCellRenderer
	{
		public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
		{
			UITableViewCell retVal = base.GetCell(item, reusableCell, tv);
			retVal.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			return (retVal);
		}
	}
}
