using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EbayBrowser.Services.Models;
using Newtonsoft.Json;

namespace EbayBrowser.Services
{
	public class EbayService : IEbayService
	{
		private const string EBAY_BASE_URL = "http://open.api.ebay.com/Shopping?version=800&appid=SPCWAREL-76b1-4a80-8d27-fc9ec8ebf413&responseencoding=JSON";
		private const string GET_CATEGORIES_URL = "&callname=GetCategoryInfo&IncludeSelector=ChildCategories";
		private const string GET_ITEMS_URL = "&callname=FindPopularItems";
        private const string GET_ITEM_DETAILS_URL = "&callname=GetSingleItem&IncludeSelector=Details";
        private const string CATEGORY_PARAM_URL = "&CategoryID=";
        private const string ITEM_PARAM_URL = "&ItemID=";
        private const string TOP_LEVEL_CATEGORY_ID = "-1";

		public async Task<List<Category>> GetCategories(Category parentCategory)
		{
			//Calculate web service url
			string url = EBAY_BASE_URL + GET_CATEGORIES_URL;
			string parentCategoryId = TOP_LEVEL_CATEGORY_ID;
			if (parentCategory != null)
				parentCategoryId = parentCategory.CategoryID;
			url += CATEGORY_PARAM_URL + parentCategoryId;
			//Execute web service
			HttpClient client = new HttpClient();
			string categoryJson = await client.GetStringAsync(url);
			GetCategoryInfoResult result = JsonConvert.DeserializeObject<GetCategoryInfoResult>(categoryJson);
            //Remove parentCategory from return value
            List<Category> retVal = result.CategoryArray.Category.Where(c => c.CategoryID != parentCategoryId).OrderBy(c => c.CategoryName).ToList();
			return (retVal);
		}

		public async Task<List<Item>> FindPopularItems(Category parentCategory)
		{
			//Calculate web service url
			string url = EBAY_BASE_URL + GET_ITEMS_URL + CATEGORY_PARAM_URL + parentCategory.CategoryID;
			//Execute web service
			HttpClient client = new HttpClient();
			string itemJson = await client.GetStringAsync(url);
			FindPopularItemsResult result = JsonConvert.DeserializeObject<FindPopularItemsResult>(itemJson);
			return (result.ItemArray.Item);
		}

        public async Task<ItemDetails> GetItemDetails(Item item)
        {
            //Calculate web service url
            string url = EBAY_BASE_URL + GET_ITEM_DETAILS_URL + ITEM_PARAM_URL + item.ItemID;
            //Execute web service
            HttpClient client = new HttpClient();
            string itemJson = await client.GetStringAsync(url);
            GetItemDetailsResult result = JsonConvert.DeserializeObject<GetItemDetailsResult>(itemJson);
            return (result.Item);
        }
    }
}
