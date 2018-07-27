using EbayBrowser.Forms.Shared.Pages;
using EbayBrowser.Services;
using Xamarin.Forms;

namespace EbayBrowser.Forms.Shared
{
	public class App : Application
	{
		public App()
		{
            DependencyService.Register<EbayService>();
            MainPage = new NavigationPage(new CategoryPage(null));
		}
	}
}
