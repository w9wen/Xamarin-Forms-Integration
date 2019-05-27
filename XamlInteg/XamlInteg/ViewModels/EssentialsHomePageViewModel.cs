﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using XamlInteg.Views;

namespace XamlInteg.ViewModels
{
    public class EssentialsHomePageViewModel : ViewModelBase
    {

       public DelegateCommand<string> ButtonCommand { get; private set; }
        public EssentialsHomePageViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
            Title = "Xamarin Essentials";
            ButtonCommand = new DelegateCommand<string>(ButtonExecute);
        }

        private void ButtonExecute(string subject)
        {
            switch (subject)
            {
                case "connectivity":
                    NavigationService.NavigateAsync(nameof(EssentialConnectivityPage));
                    break;
                case "DeviceInfo":
                    NavigationService.NavigateAsync(nameof(EssentialDeviceInfoPage));
                    break;
                default:
                    break;
            }
        }

    }
}
