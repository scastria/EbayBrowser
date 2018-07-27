using System;
using Android.Content;
using EbayBrowser.Forms.Droid.Renderers;
using EbayBrowser.Forms.Shared.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ZoomableWebView), typeof(ZoomableWebViewRenderer))]
namespace EbayBrowser.Forms.Droid.Renderers
{
    public class ZoomableWebViewRenderer : WebViewRenderer
    {
        public ZoomableWebViewRenderer(Context ctx) : base(ctx)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);
            if (Control != null) {
                Control.Settings.BuiltInZoomControls = true;
                Control.Settings.DisplayZoomControls = false;
            }
        }
    }
}
