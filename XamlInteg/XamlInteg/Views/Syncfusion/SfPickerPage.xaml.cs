using Xamarin.Forms;

namespace XamlInteg.Views
{
    public partial class SfPickerPage : ContentPage
    {
        public SfPickerPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            DatePicker_Test.IsOpen = !DatePicker_Test.IsOpen;
        }
    }
}