using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XamlInteg.ViewModels
{
    public class StickyScrollPageViewModel : BindableBase
    {
        Rectangle layoutBounds;
        double scrollY;

        public Rectangle LayoutBounds
        {
            get
            {
                return layoutBounds;
            }
            set
            {
                SetProperty(ref layoutBounds, value, () => RaisePropertyChanged());
            }
        }

        public double ScrollY
        {
            get
            {
                return scrollY;
            }
        }

        public StickyScrollPageViewModel()
        {
            layoutBounds.X = 0;
            layoutBounds.Y = 240;
            layoutBounds.Width = 360;
            layoutBounds.Height = 36;
        }
    }
}
