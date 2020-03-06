using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Java.IO;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamlInteg.Controls;
using XamlInteg.Droid.Renderers;

[assembly: ExportRenderer(typeof(WebViewControl), typeof(WebViewControlRenderer))]

namespace XamlInteg.Droid.Renderers
{
    public class WebViewControlRenderer : WebViewRenderer
    {
        private Context _context;

        public WebViewControlRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                Control.SetWebChromeClient(new CustomWebChromeClient(_context as Activity));
            }
        }

        public class CustomWebChromeClient : WebChromeClient
        {
            //private readonly ICameraService _cameraService;
            private readonly MainActivity _activity;

            public CustomWebChromeClient(Activity context)
            {
                _activity = context as MainActivity;
                //_cameraService = DependencyService.Get<ICameraService>(); // You can use your own permissions service like me or use anything else
            }

            public override bool OnShowFileChooser(Android.Webkit.WebView webView, IValueCallback filePathCallback, FileChooserParams fileChooserParams)
            {
                CreateGalleryOrCameraChooser(filePathCallback);
                return true;
            }

            private async void CreateGalleryOrCameraChooser(IValueCallback filePathCallback)
            {
                //var permissionResult = await _cameraService.GetPermissionsAsync();
                //if (!permissionResult.IsAuthorized)
                //{
                //    filePathCallback.OnReceiveValue(null);
                //    return;
                //}

                if (ContextCompat.CheckSelfPermission(_activity, Manifest.Permission.Camera) == (int)Permission.Granted)
                {
                    // We have permission, go ahead and use the camera.
                }
                else
                {
                    // Camera permission is not granted. If necessary display rationale & request.
                }

                _activity.FileUploadCallback = filePathCallback;
                Intent galleryIntent = new Intent(Intent.ActionGetContent);
                galleryIntent.SetType("image/*");

                Intent cameraIntent = new Intent(MediaStore.ActionImageCapture);
                cameraIntent.AddFlags(ActivityFlags.GrantReadUriPermission);

                //_activity.PhotoUriToUpload = Android.Net.Uri.FromFile(CreateTemporaryImageFile());

                if (cameraIntent.ResolveActivity(_activity.PackageManager) != null) // Ensure that there's a camera activity to handle the intent
                {
                    File photoFile = CreateTemporaryImageFile();
                    if (photoFile != null)
                    {
                        try
                        {
                            var fileProvider = Android.App.Application.Context.PackageName + ".fileprovider";

                            Android.Net.Uri photoUri =
                                               FileProvider.GetUriForFile(_activity, Android.App.Application.Context.PackageName, photoFile);

                            //var photoUri = Android.Net.Uri.FromFile(photoFile);

                            cameraIntent.PutExtra(MediaStore.ExtraOutput, photoUri);
                            _activity.PhotoUriToUpload = photoUri;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }

                // Create camera capture image intent and add it to the chooser
                //var captureIntent = new Intent(MediaStore.ActionImageCapture);
                //cameraIntent.PutExtra(MediaStore.ExtraOutput, _activity.PhotoUriToUpload);

                Intent chooser = new Intent(Intent.ActionChooser);
                chooser.PutExtra(Intent.ExtraIntent, galleryIntent);
                //chooser.PutExtra(Intent.ExtraTitle, AppResources.SelectPictureFromLabel);

                IParcelable[] intentArray = { cameraIntent };
                chooser.PutExtra(Intent.ExtraInitialIntents, intentArray);

                _activity.StartActivityForResult(chooser, MainActivity.FILECHOOSER_RESULTCODE);
                //_activity.StartActivityForResult(cameraIntent, MainActivity.FILECHOOSER_RESULTCODE);
            }

            private File CreateTemporaryImageFile()
            {
                // Create MyAppFolder at SD card for saving our images
                //File imageStorageDir = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(
                //        Android.OS.Environment.DirectoryPictures), "MyAppFolder");

                //if (!imageStorageDir.Exists())
                //{
                //    imageStorageDir.Mkdirs();
                //}

                //// Create camera captured image file path and name, add ticks to make it unique
                //var file = new File(imageStorageDir + File.Separator + "IMG_"
                //    + DateTime.Now.Ticks + ".jpg");

                string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string imageFileName = "JPEG_" + timeStamp + "_";
                //File storageDir = _activity.GetExternalFilesDir(Android.OS.Environment.DirectoryPictures);
                File storageDir = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures);
                File image = File.CreateTempFile(imageFileName, ".jpg", storageDir);
                return image;
            }
        }
    }
}

//[assembly: ExportRenderer(typeof(WebViewControl), typeof(WebViewControlRenderer))]

//namespace XamlInteg.Droid.Renderers
//{
//    public class WebViewControlRenderer : WebViewRenderer
//    {
//        private MainActivity context;

//        public WebViewControlRenderer(MainActivity context) : base(context)
//        {
//            this.context = context;
//        }

//        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
//        {
//            base.OnElementChanged(e);

//            //var chrome = new FileChooserWebChromeClient((uploadMsg, acceptType, capture) => {
//            //    MainActivity.mUploadMessage = uploadMsg;
//            //    var i = new Intent(Intent.ActionGetContent);
//            //    i.AddCategory(Intent.CategoryOpenable);
//            //    i.SetType("image/*");
//            //    MainActivity.StartActivityForResult(Intent.CreateChooser(i, "File Chooser"), MainActivity.FILECHOOSER_RESULTCODE);
//            //});

//            Control.Settings.JavaScriptEnabled = true;
//            Control.ClearCache(true);
//            Control.SetWebChromeClient(new FileChooserWebChromeClient(this.context));
//        }
//    }

//    partial class FileChooserWebChromeClient : WebChromeClient
//    {
//        private MainActivity context;

//        public FileChooserWebChromeClient(MainActivity context)
//        {
//            this.context = context;
//        }

//        public override void OnPermissionRequest(PermissionRequest request)
//        {
//            context.RunOnUiThread(() =>
//            {
//                request.Grant(request.GetResources());
//            });
//        }

//        public override bool OnShowFileChooser(Android.Webkit.WebView webView, IValueCallback filePathCallback, FileChooserParams fileChooserParams)
//        {
//            //return base.OnShowFileChooser(webView, filePathCallback, fileChooserParams);

//            MainActivity.mUploadMessage = filePathCallback;
//            Intent chooserIntent = fileChooserParams.CreateIntent();

//            var captureIntent = new Intent(MediaStore.ActionImageCapture);
//            chooserIntent.PutExtra(Intent.ExtraInitialIntents, new Intent[] { captureIntent });

//            this.context.StartActivityForResult(chooserIntent, MainActivity.FILECHOOSER_RESULTCODE);
//            return true;
//        }

//        //private void OnActivityResult(int requestCode, Result resultCode, Intent data)
//        //{
//        //    if (data != null)
//        //    {
//        //        if (requestCode == MainActivity.FILECHOOSER_RESULTCODE)
//        //        {
//        //            if (null == MainActivity.mUploadMessage || data == null)
//        //                return;
//        //            MainActivity.mUploadMessage.OnReceiveValue(WebChromeClient.FileChooserParams.ParseResult((int)resultCode, data));
//        //            MainActivity.mUploadMessage = null;
//        //        }
//        //    }
//        //}
//    }
//}