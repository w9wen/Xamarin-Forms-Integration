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
                var type = await CrossFingerprint.Current.GetAuthenticationTypeAsync();

                if (type == Plugin.Fingerprint.Abstractions.AuthenticationType.Fingerprint)
                {
                    await _pageDialogService.DisplayAlertAsync("本機認證", "使用指紋辨識", "Ok");
                }
                else if (type == Plugin.Fingerprint.Abstractions.AuthenticationType.Face)
                {
                    await _pageDialogService.DisplayAlertAsync("本機認證", "使用臉部辨識", "Ok");
                }
                else
                {
                    await _pageDialogService.DisplayAlertAsync("本機認證", "無", "Ok");
                }

                var available = await CrossFingerprint.Current.GetAvailabilityAsync();

                switch (available)
                {
                    case Plugin.Fingerprint.Abstractions.FingerprintAvailability.Available:
                        break;

                    case Plugin.Fingerprint.Abstractions.FingerprintAvailability.NoImplementation:
                        break;

                    case Plugin.Fingerprint.Abstractions.FingerprintAvailability.NoApi:
                        break;

                    case Plugin.Fingerprint.Abstractions.FingerprintAvailability.NoPermission:
                        break;

                    case Plugin.Fingerprint.Abstractions.FingerprintAvailability.NoSensor:
                        break;

                    case Plugin.Fingerprint.Abstractions.FingerprintAvailability.NoFingerprint:
                        break;

                    case Plugin.Fingerprint.Abstractions.FingerprintAvailability.Unknown:
                        break;

                    case Plugin.Fingerprint.Abstractions.FingerprintAvailability.Denied:
                        break;

                    default:
                        break;
                }

                var isAvailable = await CrossFingerprint.Current.IsAvailableAsync();

                if (isAvailable)
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
                else
                {
                    await _pageDialogService.DisplayAlertAsync("識別結果", "無設定生物辨識", "Ok");
                }
            }
            catch (Exception ex)
            {
            }
        }

        #endregion Methods
    }
}