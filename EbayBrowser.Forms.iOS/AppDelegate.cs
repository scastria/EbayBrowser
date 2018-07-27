using EbayBrowser.Forms.Shared;
using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace EbayBrowser.Forms.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.Forms.Forms.Init();
            CarouselView.FormsPlugin.iOS.CarouselViewRenderer.Init();
            LoadApplication(new App());
            return (base.FinishedLaunching(app, options));
        }
    }
}
