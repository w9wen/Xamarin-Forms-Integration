using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamlInteg.Controls;
using XamlInteg.Droid.Renderers;

[assembly: ExportRenderer(typeof(WebViewControl), typeof(WebViewControlRenderer))]

namespace XamlInteg.Droid.Renderers
{
    public class WebViewControlRenderer : WebViewRenderer
    {
        private MainActivity context;

        public WebViewControlRenderer(MainActivity context) : base(context)
        {
            this.context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);

            //var chrome = new FileChooserWebChromeClient((uploadMsg, acceptType, capture) => {
            //    MainActivity.mUploadMessage = uploadMsg;
            //    var i = new Intent(Intent.ActionGetContent);
            //    i.AddCategory(Intent.CategoryOpenable);
            //    i.SetType("image/*");
            //    MainActivity.StartActivityForResult(Intent.CreateChooser(i, "File Chooser"), MainActivity.FILECHOOSER_RESULTCODE);
            //});

            Control.Settings.JavaScriptEnabled = true;
            Control.ClearCache(true);
            Control.SetWebChromeClient(new FileChooserWebChromeClient(this.context));
        }
    }

    partial class FileChooserWebChromeClient : WebChromeClient
    {
        private MainActivity context;

        public FileChooserWebChromeClient(MainActivity context)
        {
            this.context = context;
        }

        public override void OnPermissionRequest(PermissionRequest request)
        {
            context.RunOnUiThread(() =>
            {
                request.Grant(request.GetResources());
            });
        }

        public override bool OnShowFileChooser(Android.Webkit.WebView webView, IValueCallback filePathCallback, FileChooserParams fileChooserParams)
        {
            //return base.OnShowFileChooser(webView, filePathCallback, fileChooserParams);

            MainActivity.mUploadMessage = filePathCallback;
            Intent chooserIntent = fileChooserParams.CreateIntent();

            var captureIntent = new Intent(MediaStore.ActionImageCapture);
            chooserIntent.PutExtra(Intent.ExtraInitialIntents, new Intent[] { captureIntent });

            this.context.StartActivityForResult(chooserIntent, MainActivity.FILECHOOSER_RESULTCODE);
            return true;
        }

        //private void OnActivityResult(int requestCode, Result resultCode, Intent data)
        //{
        //    if (data != null)
        //    {
        //        if (requestCode == MainActivity.FILECHOOSER_RESULTCODE)
        //        {
        //            if (null == MainActivity.mUploadMessage || data == null)
        //                return;
        //            MainActivity.mUploadMessage.OnReceiveValue(WebChromeClient.FileChooserParams.ParseResult((int)resultCode, data));
        //            MainActivity.mUploadMessage = null;
        //        }
        //    }
        //}
    }
}