using System;
using System.Collections.Generic;

namespace EbayBrowser.Services.Models
{
    public class Seller
    {
        public string UserID { get; set; }
        public string FeedbackRatingStar { get; set; }
        public int FeedbackScore { get; set; }
        public double PositiveFeedbackPercent { get; set; }
    }

    public class ItemDetailsConvertedCurrentPrice
    {
        public double Value { get; set; }
        public string CurrencyID { get; set; }
    }

    public class CurrentPrice
    {
        public double Value { get; set; }
        public string CurrencyID { get; set; }
    }

    public class Storefront
    {
        public string StoreURL { get; set; }
        public string StoreName { get; set; }
    }

    public class ReturnPolicy
    {
        public string ReturnsWithin { get; set; }
        public string ReturnsAccepted { get; set; }
        public string ShippingCostPaidBy { get; set; }
    }

    public class ItemDetails
    {
        public bool BestOfferEnabled { get; set; }
        public string ItemID { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
        public string ViewItemURLForNaturalSearch { get; set; }
        public string ListingType { get; set; }
        public string Location { get; set; }
        public List<string> PaymentMethods { get; set; }
        public List<string> PictureURL { get; set; }
        public string PostalCode { get; set; }
        public string PrimaryCategoryID { get; set; }
        public string PrimaryCategoryName { get; set; }
        public int Quantity { get; set; }
        public Seller Seller { get; set; }
        public int BidCount { get; set; }
        public ItemDetailsConvertedCurrentPrice ConvertedCurrentPrice { get; set; }
        public CurrentPrice CurrentPrice { get; set; }
        public string ListingStatus { get; set; }
        public int QuantitySold { get; set; }
        public List<string> ShipToLocations { get; set; }
        public string Site { get; set; }
        public string TimeLeft { get; set; }
        public string Title { get; set; }
        public int HitCount { get; set; }
        public string Subtitle { get; set; }
        public string PrimaryCategoryIDPath { get; set; }
        public Storefront Storefront { get; set; }
        public string Country { get; set; }
        public ReturnPolicy ReturnPolicy { get; set; }
        public bool AutoPay { get; set; }
        public List<object> PaymentAllowedSite { get; set; }
        public bool IntegratedMerchantCreditCardEnabled { get; set; }
        public int HandlingTime { get; set; }
        public int ConditionID { get; set; }
        public string ConditionDisplayName { get; set; }
        public string QuantityAvailableHint { get; set; }
        public int QuantityThreshold { get; set; }
        public bool GlobalShipping { get; set; }
        public int QuantitySoldByPickupInStore { get; set; }
        public bool NewBestOffer { get; set; }
        public bool AvailableForPickupDropOff { get; set; }
    }

    public class GetItemDetailsResult
    {
        public DateTime Timestamp { get; set; }
        public string Ack { get; set; }
        public string Build { get; set; }
        public string Version { get; set; }
        public ItemDetails Item { get; set; }
    }
}