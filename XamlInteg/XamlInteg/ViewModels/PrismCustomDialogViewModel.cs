using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using XamlInteg.Views;

namespace XamlInteg.ViewModels
{
    public class PrismCustomDialogViewModel : BindableBase, IDialogAware
    {
        private IDialogService dialogService;

        public DelegateCommand OpenCommand { get; }
        public DelegateCommand CloseCommand { get; }

        public PrismCustomDialogViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            this.OpenCommand = new DelegateCommand(OpenExecute);
            this.CloseCommand = new DelegateCommand(() => RequestClose(null));
        }

        private void OpenExecute()
        {
            this.dialogService.ShowDialog(nameof(PrismCustomDialog));
        }

        public event Action<IDialogParameters> RequestClose;

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}