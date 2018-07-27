using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EbayBrowser.Services;
using EbayBrowser.Services.Models;
using MvvmCross.ViewModels;

namespace EbayBrowser.Mvvm.Shared.ViewModels
{
    public class ItemsViewModel : MvxViewModel<Category>
    {
        private string _pageTitle = null;
        public string PageTitle {
            get { return _pageTitle; }
            set { _pageTitle = value; RaisePropertyChanged(() => PageTitle); }
        }
        private List<Item> _rows = null;
        public List<Item> Rows
		{
            get { return _rows; }
            set { _rows = value; RaisePropertyChanged(() => Rows); }
		}

        private IEbayService _ebayService = null;
        private Category _parentCategory = null;

        public ItemsViewModel(IEbayService ebayService)
        {
            _ebayService = ebayService;
            _rows = new List<Item>();
        }

        public override void Prepare(Category parentCategory)
        {
            _parentCategory = parentCategory;
        }

        public async override Task Initialize()
        {
            await base.Initialize();
            PageTitle = _parentCategory.CategoryName + " Items";
            Rows = await _ebayService.FindPopularItems(_parentCategory);
        }
    }
}
