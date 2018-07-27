using EbayBrowser.Mvvm.Shared;
using Foundation;
using MvvmCross.Platforms.Ios.Core;

namespace EbayBrowser.Mvvm.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate<MvxIosSetup<App>, App>
    {
    }
}
