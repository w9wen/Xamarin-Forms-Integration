using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using XamlInteg.Views;

namespace XamlInteg.ViewModels
{
    public class EssentialsHomePageViewModel : ViewModelBase
    {
        public DelegateCommand<string> ButtonCommand { get; private set; }

        public EssentialsHomePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
            Title = "Xamarin Essentials";
            ButtonCommand = new DelegateCommand<string>(ButtonExecute);
        }

        private void ButtonExecute(string subject)
        {
            switch (subject)
            {
                case "Connectivity":
                    NavigationService.NavigateAsync(nameof(EssentialConnectivityPage));
                    break;

                case "DeviceInfo":
                    NavigationService.NavigateAsync(nameof(EssentialDeviceInfoPage));
                    break;

                case "AppInfo":
                    NavigationService.NavigateAsync(nameof(EssentialAppInfoPage));
                    break;

                default:
                    break;
            }
        }
    }
}