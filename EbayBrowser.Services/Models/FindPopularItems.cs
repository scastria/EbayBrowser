using System.Collections.Generic;

namespace EbayBrowser.Services.Models
{
	public class ConvertedCurrentPrice
	{
		public double Value { get; set; }
		public string CurrencyID { get; set; }
	}

	public class ShippingServiceCost
	{
		public double Value { get; set; }
		public string CurrencyID { get; set; }
	}

	public class ListedShippingServiceCost
	{
		public double Value { get; set; }
		public string CurrencyID { get; set; }
	}

	public class ShippingCostSummary
	{
		public ShippingServiceCost ShippingServiceCost { get; set; }
		public string ShippingType { get; set; }
		public ListedShippingServiceCost ListedShippingServiceCost { get; set; }
	}

	public class OriginalRetailPrice
	{
		public double Value { get; set; }
		public string CurrencyID { get; set; }
	}

	public class DiscountPriceInfo
	{
		public OriginalRetailPrice OriginalRetailPrice { get; set; }
		public string PricingTreatment { get; set; }
		public bool SoldOneBay { get; set; }
		public bool SoldOffeBay { get; set; }
	}

	public class Item
	{
		public string ItemID { get; set; }
		public string EndTime { get; set; }
		public string ViewItemURLForNaturalSearch { get; set; }
		public string ListingType { get; set; }
		public string GalleryURL { get; set; }
		public string PrimaryCategoryID { get; set; }
		public string PrimaryCategoryName { get; set; }
		public int BidCount { get; set; }
		public ConvertedCurrentPrice ConvertedCurrentPrice { get; set; }
		public string ListingStatus { get; set; }
		public string TimeLeft { get; set; }
		public string Title { get; set; }
		public ShippingCostSummary ShippingCostSummary { get; set; }
		public int WatchCount { get; set; }
		public DiscountPriceInfo DiscountPriceInfo { get; set; }
	}

	public class ItemArray
	{
		public List<Item> Item { get; set; }
	}

	public class FindPopularItemsResult
	{
		public string Timestamp { get; set; }
		public string Ack { get; set; }
		public string Build { get; set; }
		public string Version { get; set; }
		public ItemArray ItemArray { get; set; }
	}
}
