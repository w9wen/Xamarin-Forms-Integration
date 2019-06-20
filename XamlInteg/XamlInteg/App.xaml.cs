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
        }
    }
}