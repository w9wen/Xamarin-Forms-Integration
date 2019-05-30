using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamlInteg.Views;

namespace XamlInteg.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand<string> ButtonCommand { get; private set; }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            ButtonCommand = new DelegateCommand<string>(ButtonExecute);
        }

        private void ButtonExecute(string subject)
        {
            switch (subject)
            {
                case "prism":
                    NavigationService.NavigateAsync(nameof(PrismHomePage));
                    break;
                case "essentials":
                    NavigationService.NavigateAsync(nameof(EssentialsHomePage));
                    break;
                case "android":
                    NavigationService.NavigateAsync(nameof(AndroidSpecificsPage));
                    break;
                case "Syncfusion":
                    NavigationService.NavigateAsync(nameof(SyncfusionHomePage));
                    break;
                default:
                    break;
            }
        }
    }
}
