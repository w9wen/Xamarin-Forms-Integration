using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamlInteg.ViewModels
{
    public class PrismPropertyChangedPageViewModel : ViewModelBase
    {
        private bool _isSelected;
        private string _updateText;

        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value, () => ButtonCommand.RaiseCanExecuteChanged()); }
        }

        public string UpdateText
        {
            get { return _updateText; }
            set { SetProperty(ref _updateText, value); }
        }

        public DelegateCommand ButtonCommand { get; private set; }

        public PrismPropertyChangedPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
            ButtonCommand = new DelegateCommand(ButtonExecute, ButtonCanExecute);
        }

        private void ButtonExecute()
        {
            UpdateText = $"Now is {DateTime.Now.ToString("yyyy-MM-dd")}";
        }

        private bool ButtonCanExecute()
        {
            return IsSelected;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }
    }
}