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
    public class SyncfusionHomePageViewModel : ViewModelBase
    {
        public DelegateCommand<string> ButtonCommand { get; }

        public SyncfusionHomePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
            ButtonCommand = new DelegateCommand<string>(ButtonExcecute);
        }

        private void ButtonExcecute(string subject)
        {
            switch (subject)
            {
                case "ListView":
                    NavigationService.NavigateAsync(nameof(SyncListViewPage));
                    break;

                default:
                    break;
            }
        }
    }
}