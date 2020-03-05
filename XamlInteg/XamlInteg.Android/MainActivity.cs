using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Webkit;
using Plugin.Permissions;
using Prism;
using Prism.Ioc;
using Syncfusion.XForms.Android.PopupLayout;

namespace XamlInteg.Droid
{
    [Activity(Label = "XamlInteg", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public IValueCallback FileUploadCallback { get; set; }
        public Uri PhotoUriToUpload { get; set; }
        public static readonly int FILECHOOSER_RESULTCODE = 1;
        public static readonly int REQUEST_CAMERA_TEST = 8;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Xamarin.Essentials.Platform.Init(this, bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            SfPopupLayoutRenderer.Init();

            LoadApplication(new App(new AndroidInitializer()));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (FileUploadCallback == null)
            {
                return;
            }

            if (data != null && requestCode == FILECHOOSER_RESULTCODE)
            {
                FileUploadCallback.OnReceiveValue(WebChromeClient.FileChooserParams.ParseResult((int)resultCode, data));
            }
            else if (PhotoUriToUpload != null && requestCode == FILECHOOSER_RESULTCODE)
            {
                Intent cameraPhotoIntent = new Intent(Intent.ActionView, PhotoUriToUpload);
                FileUploadCallback.OnReceiveValue(WebChromeClient.FileChooserParams.ParseResult((int)resultCode, cameraPhotoIntent));
            }
            else
            {
                FileUploadCallback.OnReceiveValue(null);
            }

            FileUploadCallback = null;
            PhotoUriToUpload = null;
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}