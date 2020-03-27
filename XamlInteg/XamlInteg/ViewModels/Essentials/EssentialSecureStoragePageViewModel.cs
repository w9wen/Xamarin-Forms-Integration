using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using Xamarin.Essentials;

namespace XamlInteg.ViewModels
{
    /// <summary>
    /// The Account Class.
    /// </summary>
    public class AccountModel
    {
        public string Account { get; set; }
        public string CardNumber { get; set; }
        public string Password { get; set; }
    }

    public class EssentialSecureStoragePageViewModel : ViewModelBase
    {
        #region Fields

        /// <summary>
        /// Store the account information.
        /// </summary>
        private AccountModel _accountInfo = new AccountModel();

        #endregion Fields

        #region Properties

        /// <summary>
        /// Store the account information.
        /// </summary>
        public AccountModel AccountInfo
        {
            get { return _accountInfo; }
            set { SetProperty(ref _accountInfo, value); }
        }

        /// <summary>
        /// Save command.
        /// </summary>
        public DelegateCommand SaveCommand { get; }

        #endregion Properties

        #region Constructor

        public EssentialSecureStoragePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
            SaveCommand = new DelegateCommand(SaveExecute);
        }

        #endregion Constructor

        #region Methods.

        /// <summary>
        /// Save execute.
        /// </summary>
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

        #endregion Methods.

        #region Override.

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

        #endregion Override.
    }
}