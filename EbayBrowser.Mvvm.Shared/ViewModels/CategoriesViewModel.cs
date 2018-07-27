using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EbayBrowser.Services;
using EbayBrowser.Services.Models;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace EbayBrowser.Mvvm.Shared.ViewModels
{
    public class CategoriesViewModel : MvxViewModel<Category>
    {
        private string _pageTitle = null;
        public string PageTitle
        {
            get { return _pageTitle; }
            set { _pageTitle = value; RaisePropertyChanged(() => PageTitle); }
        }
        private List<Category> _rows = null;
        public List<Category> Rows
		{
            get { return _rows; }
            set { _rows = value; RaisePropertyChanged(() => Rows); }
		}
        private MvxCommand<Category> _itemSelectedCommand = null;
        public IMvxCommand ItemSelectedCommand
        {
            get
            {
                _itemSelectedCommand = _itemSelectedCommand ?? new MvxCommand<Category>(DoItemSelectedCommand);
                return (_itemSelectedCommand);
            }
        }

        private IEbayService _ebayService = null;
        private Category _parentCategory = null;

        public CategoriesViewModel(IEbayService ebayService)
        {
            _ebayService = ebayService;
            _rows = new List<Category>();
        }

        public override void Prepare(Category parentCategory)
        {
            _parentCategory = parentCategory;
        }

        public async override Task Initialize()
        {
            await base.Initialize();
            PageTitle = ((_parentCategory == null) ? string.Empty : _parentCategory.CategoryName + " ") + "Categories";
            Rows = await _ebayService.GetCategories(_parentCategory);
        }

        private async void DoItemSelectedCommand(Category cat)
        {
            if (cat.LeafCategory)
                await NavigationService.Navigate<ItemsViewModel, Category>(cat);
            else
                await NavigationService.Navigate<CategoriesViewModel, Category>(cat);
        }
    }
}
