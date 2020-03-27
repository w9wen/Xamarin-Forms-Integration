using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamlInteg.Views;

namespace XamlInteg.ViewModels
{
    public class PrismHomePageViewModel : ViewModelBase
    {
        private IPageDialogService pageDialogService;

        public DelegateCommand<string> ButtonCommand
        { get; private set; }

        public DelegateCommand PrismDisplayAlertCommad { get; }

        public PrismHomePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
            Title = "Prism Library";
            this.pageDialogService = pageDialogService;

            ButtonCommand = new DelegateCommand<string>(ButtonExecute);
            this.PrismDisplayAlertCommad = new DelegateCommand(PrismDisplayAlertExecute);
        }

        private void PrismDisplayAlertExecute()
        {
            this.pageDialogService.DisplayAlertAsync("Title", "Message", "確定").ConfigureAwait(true);
        }

        private void ButtonExecute(string subject)
        {
            switch (subject)
            {
                case "property_changed":
                    var parameters = new NavigationParameters();
                    parameters.Add("testKey", "testValue");

                    NavigationService.NavigateAsync(nameof(PrismPropertyChangedPage), parameters);
                    break;

                default:
                    break;
            }
        }
    }
}