using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;

namespace XamlInteg.ViewModels
{
    public class EssentialAppInfoPageViewModel : BindableBase
    {
        public string Name => AppInfo.Name;
        public string PackageName => AppInfo.PackageName;
        public string BuildString => AppInfo.BuildString;
        public Version Version => AppInfo.Version;
        public string VersionString => AppInfo.VersionString;

        public DelegateCommand ShowSettingsUICommand { get; }
        public EssentialAppInfoPageViewModel()
        {
            ShowSettingsUICommand = new DelegateCommand(() => AppInfo.ShowSettingsUI());
        }
    }
}
