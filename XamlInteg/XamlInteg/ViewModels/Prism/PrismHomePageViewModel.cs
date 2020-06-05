using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
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
        private IDialogService dialogService;

        public DelegateCommand<string> ButtonCommand
        { get; private set; }

        public DelegateCommand PrismDisplayAlertCommad { get; }

        public DelegateCommand ShowCustomDialog { get; }

        public PrismHomePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDialogService dialogService)
            : base(navigationService, pageDialogService)
        {
            Title = "Prism Library";
            this.pageDialogService = pageDialogService;
            this.dialogService = dialogService;

            ButtonCommand = new DelegateCommand<string>(ButtonExecute);
            this.PrismDisplayAlertCommad = new DelegateCommand(PrismDisplayAlertExecute);
            this.ShowCustomDialog = new DelegateCommand(ShowCustomExecute);
        }

        private void ShowCustomExecute()
        {
            this.dialogService.ShowDialog(nameof(PrismCustomDialog));
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