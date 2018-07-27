using System;
using EbayBrowser.Forms.iOS.Renderers;
using EbayBrowser.Forms.Shared.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ZoomableWebView), typeof(ZoomableWebViewRenderer))]
namespace EbayBrowser.Forms.iOS.Renderers
{
    public class ZoomableWebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            ScalesPageToFit = true;
        }
    }
}
