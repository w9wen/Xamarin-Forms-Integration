using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;

namespace XamlInteg.ViewModels
{
    public class EssentialFlashlightPageViewModel : BindableBase
    {
        private bool turnOn;

        public bool TurnOn { get => turnOn; set => SetProperty(ref turnOn, value, () => TurnOnAsync(value)); }

        public EssentialFlashlightPageViewModel()
        {
        }

        private async void TurnOnAsync(bool turnOn)
        {
            try
            {
                if (turnOn)
                {
                    await Flashlight.TurnOnAsync();
                }
                else
                {
                    await Flashlight.TurnOffAsync();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}