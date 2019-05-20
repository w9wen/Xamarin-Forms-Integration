﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using XamarinFormsIntegration.Views;

namespace XamarinFormsIntegration.ViewModels
{
    public class PrismHomePageViewModel : ViewModelBase
    {
        public DelegateCommand<string> ButtonCommand { get; private set; }
        public PrismHomePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Prism Library";
            ButtonCommand = new DelegateCommand<string>(ButtonExecute);
        }

        private void ButtonExecute(string subject)
        {
            switch (subject)
            {
                case "property_changed":
                    NavigationService.NavigateAsync(nameof(PrismPropertyChangedPage));
                    break;
                default:
                    break;
            }
        }
    }
}
