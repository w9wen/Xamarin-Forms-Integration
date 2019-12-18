using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XamlInteg.ViewModels
{
    public class PrismTabbedPageViewModel : BindableBase
    {
        #region Properties

        public DelegateCommand<TabbedPage> CurrentPageChangedCommand { get; }

        #endregion Properties

        #region Constructor

        public PrismTabbedPageViewModel()
        {
            this.CurrentPageChangedCommand = new DelegateCommand<TabbedPage>(CurrentPageChangedExecute);
        }

        #endregion Constructor

        #region Methods

        private void CurrentPageChangedExecute(TabbedPage obj)
        {
        }

        #endregion Methods
    }
}