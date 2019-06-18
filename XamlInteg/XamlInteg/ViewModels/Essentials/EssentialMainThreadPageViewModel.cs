using Prism.Commands;
using Prism.Navigation;
using System.Threading.Tasks;

namespace XamlInteg.ViewModels
{
    public class EssentialMainThreadPageViewModel : ViewModelBase
    {
        #region Fields

        private int _countdown;

        #endregion Fields

        #region Properties

        public DelegateCommand StartCommand { get; }

        public int Countdown
        {
            get { return _countdown; }
            set { SetProperty(ref _countdown, value); }
        }

        #endregion Properties

        #region Constructor

        public EssentialMainThreadPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            StartCommand = new DelegateCommand(StartExecute);
        }

        #endregion Constructor

        #region Methods

        private async void StartExecute()
        {
            IsBusy = true;
            await Task.Run(async () =>
           {
               for (int i = 0; i < 5; i++)
               {
                   Countdown = i;
                   await Task.Delay(1000);
               }
           }
                );
            IsBusy = false;
        }

        #endregion Methods
    }
}