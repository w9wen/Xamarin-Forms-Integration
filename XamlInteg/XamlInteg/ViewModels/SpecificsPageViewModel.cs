using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamlInteg.ViewModels
{
    public class SpecificsPageViewModel : BindableBase
    {
        #region Fields

        private string formateTargetItem;

        #endregion Fields

        #region Properties

        public string FormatTargetItem { get => formateTargetItem; set => SetProperty(ref formateTargetItem, value); }

        #endregion Properties

        #region Constructor

        public SpecificsPageViewModel()
        {
            FormatTargetItem = "姓名_學號_座號";
        }

        #endregion Constructor
    }
}