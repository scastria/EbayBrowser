using System;
using System.Threading.Tasks;
using CarouselView.FormsPlugin.Abstractions;
using EbayBrowser.Forms.Shared.Controls;
using EbayBrowser.Forms.Shared.Converters;
using EbayBrowser.Services;
using EbayBrowser.Services.Models;
using Xamarin.Forms;

namespace EbayBrowser.Forms.Shared.Pages
{
    public class ItemDetailsPage : AbstractPage
    {
        private Item _item = null;
        private CarouselViewControl _carouselV = null;

        public ItemDetailsPage(Item item)
        {
            _item = item;
            Title = "Item Photos";
            //Setup carousel
            DataTemplate it = new DataTemplate(typeof(ZoomableWebView));
            it.SetBinding(ZoomableWebView.SourceProperty, new Binding(".", converter: new ImageUrlHtmlValueConverter()));
            _carouselV = new CarouselViewControl {
                ShowIndicators = true,
                ShowArrows = false,
                InterPageSpacing = 10,
                ItemTemplate = it
            };
            Content = _carouselV;
        }

        protected override async Task LoadData()
        {
            IEbayService ebayService = DependencyService.Get<IEbayService>();
            ItemDetails itemDetails = await ebayService.GetItemDetails(_item);
            _carouselV.ItemsSource = itemDetails.PictureURL;
        }
    }
}
