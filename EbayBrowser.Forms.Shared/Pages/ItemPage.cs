using System.Collections.Generic;
using System.Threading.Tasks;
using EbayBrowser.Forms.Shared.Controls;
using EbayBrowser.Services;
using EbayBrowser.Services.Models;
using Xamarin.Forms;

namespace EbayBrowser.Forms.Shared.Pages
{
    public class ItemPage : AbstractPage
	{
		private Category _parentCategory;
		private ListView _listV;

		public ItemPage(Category parentCategory)
		{
			_parentCategory = parentCategory;
			Title = parentCategory.CategoryName + " Items";
			//Setup list
			DataTemplate it = new DataTemplate(typeof(ItemCell));
			_listV = new ListView {
				HasUnevenRows = true,
				ItemTemplate = it
			};
            //Handle list selection
            _listV.ItemTapped += async delegate (object sender, ItemTappedEventArgs itea) {
                Item selItem = itea.Item as Item;
                if (selItem == null)
                    return;
                //Clear selected item
                _listV.SelectedItem = null;
                await Navigation.PushAsync(new ItemDetailsPage(selItem));
            };
            Content = _listV;
		}

        protected override async Task LoadData()
        {
			IEbayService ebayService = DependencyService.Get<IEbayService>();
			List<Item> items = await ebayService.FindPopularItems(_parentCategory);
			_listV.ItemsSource = items;
		}
	}
}
