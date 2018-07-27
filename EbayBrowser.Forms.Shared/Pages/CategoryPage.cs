using System.Collections.Generic;
using System.Threading.Tasks;
using EbayBrowser.Forms.Shared.Controls;
using EbayBrowser.Services;
using EbayBrowser.Services.Models;
using Xamarin.Forms;

namespace EbayBrowser.Forms.Shared.Pages
{
    public class CategoryPage : AbstractPage
	{
		private ListView _listV;
		private Category _parentCategory;

		public CategoryPage(Category parentCategory)
		{
			_parentCategory = parentCategory;
			Title = ((parentCategory == null) ? "Root" : parentCategory.CategoryName) + " Categories";
			//Setup list
			DataTemplate it = new DataTemplate(typeof(CategoryCell));
            it.SetBinding(TextCell.TextProperty, nameof(Category.CategoryName));
			_listV = new ListView {
				ItemTemplate = it
			};
			//Handle list selection
			_listV.ItemTapped += async delegate (object sender, ItemTappedEventArgs itea) {
				Category selCategory = itea.Item as Category;
				if (selCategory == null)
					return;
				//Clear selected item
				_listV.SelectedItem = null;
				if (selCategory.LeafCategory)
					await Navigation.PushAsync(new ItemPage(selCategory));
				else
					await Navigation.PushAsync(new CategoryPage(selCategory));
			};
			Content = _listV;
		}

		protected override async Task LoadData()
		{
			IEbayService ebayService = DependencyService.Get<IEbayService>();
			List<Category> categories = await ebayService.GetCategories(_parentCategory);
			_listV.ItemsSource = categories;
		}
	}
}
