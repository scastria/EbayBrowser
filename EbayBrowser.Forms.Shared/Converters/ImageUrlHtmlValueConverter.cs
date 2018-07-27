using System;
using System.Globalization;
using Xamarin.Forms;

namespace EbayBrowser.Forms.Shared.Converters
{
    //https://stackoverflow.com/questions/6169666/how-to-resize-an-image-to-fit-in-the-browser-window
    public class ImageUrlHtmlValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return ((HtmlWebViewSource)null);
            UriBuilder imageUrl = new UriBuilder(value.ToString()) {
                Scheme = Uri.UriSchemeHttps,
                Port = -1
            };
            HtmlWebViewSource webSource = new HtmlWebViewSource {
                Html = "<html><head><style>*{margin:0;padding:0;}.imgbox{display:grid;height:100%;}.center-fit{max-width:100%;max-height:100vh;margin:auto;}</style></head><body><div class='imgbox'><img class='center-fit' src='" + imageUrl + "'/></div></body></html>"
            };
            return (webSource);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
