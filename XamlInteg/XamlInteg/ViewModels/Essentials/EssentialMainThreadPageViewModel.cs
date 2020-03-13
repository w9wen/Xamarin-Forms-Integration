using Prism.Commands;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamlInteg.ViewModels
{
    public class EssentialMainThreadPageViewModel : ViewModelBase
    {
        #region Fields

        private bool isOn;
        private DateTime startDateTime;
        private DateTime nowDateTime;
        private int _countdown;
        private string runTime;

        #endregion Fields

        #region Properties

        public DelegateCommand<object> StartCommand { get; }

        public DateTime StartDateTime { get => startDateTime; set => SetProperty(ref startDateTime, value); }

        public DateTime NowDateTime { get => nowDateTime; set => SetProperty(ref nowDateTime, value); }
        public string RunTime { get => runTime; set => SetProperty(ref runTime, value); }

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
            StartCommand = new DelegateCommand<object>(StartExecute);
        }

        #endregion Constructor

        #region Methods

        private async void StartExecute(object on)
        {
            this.isOn = bool.Parse(on.ToString());

            if (this.isOn)
            {
                this.IsBusy = true;
                this.StartDateTime = DateTime.Now;
                Countdown = 0;
            }
            else
            {
                this.IsBusy = false;
            }

            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                if (this.isOn)
                {
                    this.IsBusy = true;

                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        this.NowDateTime = DateTime.Now;
                        var vvv = this.NowDateTime - this.StartDateTime;
                        this.RunTime = (this.NowDateTime - this.StartDateTime).ToString();
                    });
                    return true;
                }
                else
                {
                    this.IsBusy = false;
                    return false;
                }
            });

            await Task.Run(async () =>
            {
                while (this.isOn)
                {
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        Countdown++;
                    });
                    await Task.Delay(1000).ConfigureAwait(false);
                }
            }).ConfigureAwait(false);
        }

        #endregion Methods
    }
}