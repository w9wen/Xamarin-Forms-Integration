using Xamarin.Forms;

namespace XamlInteg.Views
{
    public partial class ParallaxControlPage : ContentPage
    {
        private const int parallaxSpeed = 4;

        private double lastScroll;

        public ParallaxControlPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MainScroll.ParallaxView = HeaderView;
            MainScroll.Scrolled += OnParallaxScrollScrolled;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MainScroll.Scrolled -= OnParallaxScrollScrolled;
        }

        private void OnParallaxScrollScrolled(object sender, ScrolledEventArgs e)
        {
            double translation = 0;

            if (lastScroll == 0)
            {
                lastScroll = e.ScrollY;
            }

            if (lastScroll < e.ScrollY)
            {
                translation = 0 - ((e.ScrollY / parallaxSpeed));

                if (translation > 0) translation = 0;
            }
            else
            {
                translation = 0 + ((e.ScrollY / parallaxSpeed));

                if (translation > 0) translation = 0;
            }

            //SubHeaderView.FadeTo(translation < -40 ? 0 : 1);

            lastScroll = e.ScrollY;
        }
    }
}