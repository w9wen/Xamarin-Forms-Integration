using Syncfusion.SfPullToRefresh.XForms.iOS;
using Syncfusion.SfPdfViewer.XForms.iOS;
using Syncfusion.SfRangeSlider.XForms.iOS;
using Syncfusion.SfPicker.XForms.iOS;
using Syncfusion.XForms.iOS.BadgeView;
using Syncfusion.SfDataGrid.XForms.iOS;
using Syncfusion.XForms.iOS.ParallaxView;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.XForms.iOS.TabView;
using Syncfusion.XForms.iOS.MaskedEdit;
using Syncfusion.XForms.iOS.TextInputLayout;
using Syncfusion.XForms.iOS.ComboBox;
using Syncfusion.XForms.iOS.Buttons;
using Syncfusion.XForms.iOS.PopupLayout;
using Foundation;
using Prism;
using Prism.Ioc;
using UIKit;

namespace XamlInteg.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            SfSwitchRenderer.Init();
            SfPullToRefreshRenderer.Init();
            SfPdfDocumentViewRenderer.Init();
            SfRangeSliderRenderer.Init();
            SfPickerRenderer.Init();
            SfBadgeViewRenderer.Init();
            SfDataGridRenderer.Init();
            SfParallaxViewRenderer.Init();
            SfListViewRenderer.Init();
            SfTabViewRenderer.Init();
            SfMaskedEditRenderer.Init();
            SfButtonRenderer.Init();
            SfTextInputLayoutRenderer.Init();
            SfComboBoxRenderer.Init();
            SfCheckBoxRenderer.Init();

            SfPopupLayoutRenderer.Init();
            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(app, options);
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}