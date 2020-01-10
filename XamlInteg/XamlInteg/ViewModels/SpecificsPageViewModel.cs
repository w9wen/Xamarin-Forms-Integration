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
        private string contentUrl;

        #endregion Fields

        #region Properties

        public string FormatTargetItem { get => formateTargetItem; set => SetProperty(ref formateTargetItem, value); }

        public string ContentUrl { get => contentUrl; set => SetProperty(ref contentUrl, value); }

        #endregion Properties

        #region Constructor

        public SpecificsPageViewModel()
        {
            FormatTargetItem = "姓名_學號_座號";

            this.ContentUrl = @"http://trial.shin-her.com.tw/ICampus/Announcement/APIView?Id=a89924bd0109c9370c963a88dbbde32d28976c7c416808fdfb6f3bb728b9278bbca9976d8376136b8ba4371aebaa20c1ef674a6732a27da968008e785aad9d992f972443a0a0edfb8d9a2859c0f01ca6bb09a4581d74b4fc6a1c45b6af3fb8814cbbd5452dee5840f1c24461bb9cb39a4ee24544f924d13ab886829ae8f2c310487a768a7b07bdfa37390cf31f649ab6e7460f5d00af9246c79527c1394cf20a036c3c97dcc05fe3d2e776c964d91202f12e297e68db1fce646ebb8ef3fdb218d51845d238fb5c3cd3b519dad9dab530a948bf97ec9043432f77863210e587fd";
        }

        #endregion Constructor
    }
}