using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;

namespace XamlInteg.ViewModels
{
    public class EssentialConnectivityPageViewModel : ViewModelBase
    {
        public NetworkAccess NetworkAccess => Connectivity.NetworkAccess;
        public string ConnectionProfiles
        {
            get
            {
                var profiles = string.Empty;
                foreach (var p in Connectivity.ConnectionProfiles)
                    profiles += "\n" + p.ToString();
                return profiles;
            }
        }

        public EssentialConnectivityPageViewModel(INavigationService navagaionService)
            :base(navagaionService)
        {
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(NetworkAccess));
            RaisePropertyChanged(nameof(ConnectionProfiles));
        }
    }
}
