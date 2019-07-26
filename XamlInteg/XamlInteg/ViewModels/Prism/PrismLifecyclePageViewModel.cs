using Prism.Navigation;

namespace XamlInteg.ViewModels
{
    public class PrismLifecyclePageViewModel : ViewModelBase
    {
        #region Constructor

        public PrismLifecyclePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }

        #endregion Constructor

        #region Override

        /// <summary>
        /// Before the View is navigated.
        /// </summary>
        /// <param name="parameters"></param>
        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
        }

        /// <summary>
        /// View is natigated.
        /// </summary>
        /// <param name="parameters"></param>
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.TryGetValue(KnownNavigationParameters.XamlParam, out object fooObject))
            {
                // do something with fooObject
            }
        }

        /// <summary>
        /// View is natigated away.
        /// </summary>
        /// <param name="parameters"></param>
        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        #endregion Override
    }
}