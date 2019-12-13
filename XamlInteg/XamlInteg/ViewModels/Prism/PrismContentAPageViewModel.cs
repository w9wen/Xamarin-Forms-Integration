using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.TabbedPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamlInteg.ViewModels
{
    public class PrismContentAPageViewModel : ViewModelBase, IConfirmNavigation
    {
        public DelegateCommand SelectTabCommand { get; }

        public PrismContentAPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            SelectTabCommand = new DelegateCommand(SelectTabExecute);
        }

        private void SelectTabExecute()
        {
            NavigationService.SelectTabAsync("PrismContentBPage");
        }

        public bool CanNavigate(INavigationParameters parameters)
        {
            return true;
        }
    }
}