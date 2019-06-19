using Xamarin.Forms;

namespace XamlInteg.Views
{
    public partial class SfPopupLayoutPage : ContentPage
    {
        public SfPopupLayoutPage()
        {
            InitializeComponent();
        }

        private void CheckBox_ShowPopup_StateChanged(object sender, Syncfusion.XForms.Buttons.StateChangedEventArgs e)
        {
            PopupLayout_Test.Show(0, 0);
        }
    }
}
