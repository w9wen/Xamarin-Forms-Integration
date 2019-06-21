using Plugin.Fingerprint;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using System;

namespace XamlInteg.ViewModels
{
    public class FingerprintPageViewModel : BindableBase
    {
        private IPageDialogService _pageDialogService;

        #region Properties

        public DelegateCommand CheckCommand { get; }

        #endregion Properties

        #region Constructor

        public FingerprintPageViewModel(IPageDialogService pageDialogService)
        {
            _pageDialogService = pageDialogService;
            CheckCommand = new DelegateCommand(CheckExecute);
        }

        #endregion Constructor

        #region Methods

        private async void CheckExecute()
        {
            try
            {
                var result = await CrossFingerprint.Current.AuthenticateAsync("請使用您的指紋進行識別");
                if (result.Authenticated)
                {
                    await _pageDialogService.DisplayAlertAsync("識別結果", "認證合法", "Ok");
                }
                else
                {
                    await _pageDialogService.DisplayAlertAsync("識別結果", "認證不合法", "Ok");
                }
            }
            catch (Exception ex)
            {
            }
        }

        #endregion Methods
    }
}