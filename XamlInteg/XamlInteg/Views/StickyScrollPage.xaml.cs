using Xamarin.Forms;

namespace XamlInteg.Views
{
    public partial class StickyScrollPage : ContentPage
    {

        public StickyScrollPage()
        {
            InitializeComponent();
        }

        private void Scroll_Pic_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (e.ScrollY >= 240)
            {
                AbsoluteLayout.SetLayoutBounds(Label_Pic2, new Rectangle(0, e.ScrollY -5, 360, 36));
            }
            else
            {
                AbsoluteLayout.SetLayoutBounds(Label_Pic2, new Rectangle(0, 240, 360, 36));
            }
        }
    }


}
