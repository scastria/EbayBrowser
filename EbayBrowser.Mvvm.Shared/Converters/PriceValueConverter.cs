using System;
using System.Globalization;
using EbayBrowser.Services.Models;
using MvvmCross.Converters;

namespace EbayBrowser.Mvvm.Shared.Converters
{
    public class PriceValueConverter : IMvxValueConverter
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
