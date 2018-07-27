using System.Collections.Generic;

namespace EbayBrowser.Services.Models
{
	public class Category
	{
		public string CategoryID { get; set; }
		public int CategoryLevel { get; set; }
		public string CategoryName { get; set; }
		public string CategoryParentID { get; set; }
		public bool LeafCategory { get; set; }
		public string CategoryNamePath { get; set; }
		public string CategoryIDPath { get; set; }
	}

	public class CategoryArray
	{
		public List<Category> Category { get; set; }
	}

	public class GetCategoryInfoResult
	{
		public string Timestamp { get; set; }
		public string Ack { get; set; }
		public string Build { get; set; }
		public string Version { get; set; }
		public CategoryArray CategoryArray { get; set; }
		public int CategoryCount { get; set; }
		public string UpdateTime { get; set; }
		public string CategoryVersion { get; set; }
	}
}
