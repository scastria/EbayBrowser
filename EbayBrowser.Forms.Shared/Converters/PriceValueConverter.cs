using System;
using System.Globalization;
using EbayBrowser.Services.Models;
using Xamarin.Forms;

namespace EbayBrowser.Forms.Shared.Converters
{
	public class PriceValueConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
            ConvertedCurrentPrice ccp = (ConvertedCurrentPrice)value;
            return ("$" + ccp.Value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
