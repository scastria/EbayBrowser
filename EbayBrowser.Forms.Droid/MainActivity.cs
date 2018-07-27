using Android.App;
using Android.Content.PM;
using Android.OS;
using EbayBrowser.Forms.Shared;
using Xamarin.Forms.Platform.Android;

namespace EbayBrowser.Forms.Droid
{
    [Activity(Label = "Forms Ebay", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            CarouselView.FormsPlugin.Android.CarouselViewRenderer.Init();
            LoadApplication(new App());
        }
    }
}