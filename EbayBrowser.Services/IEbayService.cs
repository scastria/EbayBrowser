using System.Collections.Generic;
using System.Threading.Tasks;
using EbayBrowser.Services.Models;

namespace EbayBrowser.Services
{
	public interface IEbayService
	{
		Task<List<Category>> GetCategories(Category parentCategory);
		Task<List<Item>> FindPopularItems(Category parentCategory);
        Task<ItemDetails> GetItemDetails(Item item);
	}
}
