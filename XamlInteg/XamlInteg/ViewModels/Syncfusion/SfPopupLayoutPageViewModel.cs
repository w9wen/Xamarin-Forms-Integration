using Prism.Commands;
using Prism.Mvvm;
using Syncfusion.XForms.PopupLayout;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamlInteg.ViewModels
{
    public class SfPopupLayoutPageViewModel : BindableBase
    {
        public DelegateCommand<SfPopupLayout> ShowPopupCommand { get; }

        public SfPopupLayoutPageViewModel()
        {
            ShowPopupCommand = new DelegateCommand<SfPopupLayout>(ShowPopupExecute);
        }

        private void ShowPopupExecute(SfPopupLayout popupLayout)
        {
            popupLayout.Show();
        }
    }
}