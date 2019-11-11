using System;
using Xamarin.Forms;

namespace XamlInteg.Views
{
    public partial class RadPopupPage : ContentPage
    {
        public RadPopupPage()
        {
            InitializeComponent();
        }

        private void ClosePopup(object sender, EventArgs e)
        {
            popup.IsOpen = false;
        }

        private void ShowPopup(object sender, EventArgs e)
        {
            popup.IsOpen = true;
        }
    }
}