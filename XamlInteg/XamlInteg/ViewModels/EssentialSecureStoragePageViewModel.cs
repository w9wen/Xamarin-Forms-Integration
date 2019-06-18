using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;

namespace XamlInteg.ViewModels
{
    public class EssentialSecureStoragePageViewModel : ViewModelBase
    {
        private AccountModel _accountInfo = new AccountModel();

        public AccountModel AccountInfo
        {
            get { return _accountInfo; }
            set { SetProperty(ref _accountInfo, value); }
        }

        public DelegateCommand SaveCommand { get; }

        public EssentialSecureStoragePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            SaveCommand = new DelegateCommand(SaveExecute);
        }

        private async void SaveExecute()
        {
            try
            {
                var jsonAccountInfo = JsonConvert.SerializeObject(AccountInfo);

                await SecureStorage.SetAsync("account_info", jsonAccountInfo);
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            try
            {
                var strSecure = await SecureStorage.GetAsync("account_info");
                AccountInfo = JsonConvert.DeserializeObject<AccountModel>(strSecure);
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }
        }
    }

    public class AccountModel
    {
        public string Account { get; set; }
        public string CardNumber { get; set; }
        public string Password { get; set; }
    }
}