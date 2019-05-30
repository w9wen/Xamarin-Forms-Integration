using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;

namespace XamlInteg.ViewModels
{
    public class EssentialDeviceInfoPageViewModel : BindableBase
    {

        /// <summary>
        /// Device Model (SMG-950U, iPhone10,6)
        /// </summary>
        public string Model => DeviceInfo.Model;

        // Manufacturer (Samsung)
        public string Manufacturer => DeviceInfo.Manufacturer;

        // Device Name (Motz's iPhone)
        public string Name => DeviceInfo.Name;

        // Operating System Version Number (7.0)
        public string Version => DeviceInfo.VersionString;

        // Platform (Android)
        public DevicePlatform Platform => DeviceInfo.Platform;

        // Idiom (Phone)
        public DeviceIdiom Idiom => DeviceInfo.Idiom; 

        // Device Type (Physical)
        public DeviceType Type => DeviceInfo.DeviceType;

        public EssentialDeviceInfoPageViewModel()
        {

        }
    }
}
