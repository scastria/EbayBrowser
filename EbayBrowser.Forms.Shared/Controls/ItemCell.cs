using EbayBrowser.Forms.Shared.Converters;
using EbayBrowser.Services.Models;
using Xamarin.Forms;

namespace EbayBrowser.Forms.Shared.Controls
{
	public class ItemCell : ViewCell
	{
		public ItemCell()
		{
			Label titleL = new Label();
			Label priceL = new Label {
				HorizontalTextAlignment = TextAlignment.End,
				FontAttributes = FontAttributes.Bold,
				FontSize = 12
			};
			Image galleryI = new Image();
			Grid mainG = new Grid {
				Padding = new Thickness(10),
				RowDefinitions = {
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto }
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength(1,GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength(4,GridUnitType.Star) }
				}
			};
			mainG.Children.Add(galleryI, 0, 0);
			Grid.SetRowSpan(galleryI, 2);
			mainG.Children.Add(titleL, 1, 0);
			mainG.Children.Add(priceL, 1, 1);
			View = mainG;
			//Bindings
            galleryI.SetBinding(Image.SourceProperty, nameof(Item.GalleryURL));
            titleL.SetBinding(Label.TextProperty, nameof(Item.Title));
            priceL.SetBinding(Label.TextProperty, nameof(Item.ConvertedCurrentPrice), converter: new PriceValueConverter());
		}
	}
}
