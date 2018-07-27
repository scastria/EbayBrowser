using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EbayBrowser.Forms.Shared.Pages
{
	public abstract class AbstractPage : ContentPage
    {
        protected abstract Task LoadData();

        protected bool _isDirty = true;

        protected AbstractPage()
        {
            NavigationPage.SetBackButtonTitle(this, "Back");
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (_isDirty) {
                await LoadData();
                _isDirty = false;
            }
        }
    }
}
