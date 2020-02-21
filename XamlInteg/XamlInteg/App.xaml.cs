using Prism;
using Prism.Ioc;
using XamlInteg.ViewModels;
using XamlInteg.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace XamlInteg
{
    public partial class App
    {
        /*
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor.
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */

        public App() : this(null)
        {
        }

        public App(IPlatformInitializer initializer) : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTg0MjA5QDMxMzcyZTM0MmUzMFBOZTVTZndoeFBJY1hKNGhwcys4SHo5Z3A0QTNkcGtYY2gvSi9YcTc3aVU9");
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
            // await NavigationService.NavigateAsync(nameof(SfPopupLayoutPage));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<PrismHomePage, PrismHomePageViewModel>();
            containerRegistry.RegisterForNavigation<PrismPropertyChangedPage, PrismPropertyChangedPageViewModel>();
            containerRegistry.RegisterForNavigation<EssentialsHomePage, EssentialsHomePageViewModel>();
            containerRegistry.RegisterForNavigation<EssentialConnectivityPage, EssentialConnectivityPageViewModel>();
            containerRegistry.RegisterForNavigation<EssentialDeviceInfoPage, EssentialDeviceInfoPageViewModel>(); containerRegistry.RegisterForNavigation<EssentialDeviceInfoPage, EssentialDeviceInfoPageViewModel>();
            containerRegistry.RegisterForNavigation<EssentialAppInfoPage, EssentialAppInfoPageViewModel>();
            containerRegistry.RegisterForNavigation<AndroidSpecificsPage, AndroidSpecificsPageViewModel>();
            containerRegistry.RegisterForNavigation<SyncfusionHomePage, SyncfusionHomePageViewModel>();
            containerRegistry.RegisterForNavigation<SyncListViewPage, SyncListViewPageViewModel>();
            containerRegistry.RegisterForNavigation<StickyScrollPage, StickyScrollPageViewModel>();
            containerRegistry.RegisterForNavigation<FormsPage, FormsPageViewModel>();
            containerRegistry.RegisterForNavigation<SfPopupLayoutPage, SfPopupLayoutPageViewModel>();
            containerRegistry.RegisterForNavigation<EssentialSecureStoragePage, EssentialSecureStoragePageViewModel>();
            containerRegistry.RegisterForNavigation<EssentialMainThreadPage, EssentialMainThreadPageViewModel>();
            containerRegistry.RegisterForNavigation<PrismLifecyclePage, PrismLifecyclePageViewModel>();
            containerRegistry.RegisterForNavigation<EssentialFileSystemHelperPage, EssentialFileSystemHelperPageViewModel>();
            containerRegistry.RegisterForNavigation<PluginsHomePage, PluginsHomePageViewModel>();
            containerRegistry.RegisterForNavigation<FingerprintPage, FingerprintPageViewModel>();
            containerRegistry.RegisterForNavigation<SfTabViewPage, SfTabViewPageViewModel>(); containerRegistry.RegisterForNavigation<SfTabViewPage, SfTabViewPageViewModel>();
            containerRegistry.RegisterForNavigation<ControlsHomePage, ControlsHomePageViewModel>();
            containerRegistry.RegisterForNavigation<WebViewPage, WebViewPageViewModel>();
            containerRegistry.RegisterForNavigation<SfParallaxViewPage, SfParallaxViewPageViewModel>();
            containerRegistry.RegisterForNavigation<CustomControlsHomePage, CustomControlsHomePageViewModel>();
            containerRegistry.RegisterForNavigation<ParallaxControlPage, ParallaxControlPageViewModel>();
            containerRegistry.RegisterForNavigation<SfBadgeViewPage, SfBadgeViewPageViewModel>();
            containerRegistry.RegisterForNavigation<PrismEventToCommandBehaviorPage, PrismEventToCommandBehaviorPageViewModel>();
            containerRegistry.RegisterForNavigation<SfPickerPage, SfPickerPageViewModel>();
            containerRegistry.RegisterForNavigation<SfPdfViewerPage, SfPdfViewerPageViewModel>();
            containerRegistry.RegisterForNavigation<SfPdfViewerContentPage, SfPdfViewerContentPageViewModel>();
            containerRegistry.RegisterForNavigation<RadPopupPage, RadPopupPageViewModel>();
            containerRegistry.RegisterForNavigation<RadAutoCompletePage, RadAutoCompletePageViewModel>();
            containerRegistry.RegisterForNavigation<TelerikHomePage, TelerikHomePageViewModel>();
            containerRegistry.RegisterForNavigation<PrismTabbedPage, PrismTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<PrismNavigationAPage, PrismNavigationAPageViewModel>();
            containerRegistry.RegisterForNavigation<PrismNavigationBPage, PrismNavigationBPageViewModel>();
            containerRegistry.RegisterForNavigation<PrismContentAPage, PrismContentAPageViewModel>();
            containerRegistry.RegisterForNavigation<PrismContentBPage, PrismContentBPageViewModel>();
            containerRegistry.RegisterForNavigation<EssentialFlashlightPage, EssentialFlashlightPageViewModel>();
            containerRegistry.RegisterForNavigation<SpecificsPage, SpecificsPageViewModel>();
            containerRegistry.RegisterForNavigation<SfGaugePage, SfGaugePageViewModel>();
        }
    }
}