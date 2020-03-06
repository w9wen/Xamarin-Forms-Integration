using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamlInteg.Controls;
using XamlInteg.iOS.Renderers;

[assembly: ExportRenderer(typeof(WebViewControl), typeof(WebViewControlRenderer))]

namespace XamlInteg.iOS.Renderers
{
    public class WebViewControlRenderer : WkWebViewRenderer
    {
        public WebViewControlRenderer()
        {
        }
    }
}