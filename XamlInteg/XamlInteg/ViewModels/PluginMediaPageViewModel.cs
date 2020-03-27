using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamlInteg.ViewModels
{
    public class PluginMediaPageViewModel : ViewModelBase
    {
        #region Properties

        private string imagePath;

        public string ImagePath
        {
            get { return imagePath; }
            set { SetProperty(ref imagePath, value); }
        }

        private ImageSource image;

        public ImageSource Image
        {
            get { return image; }
            set { SetProperty(ref image, value); }
        }

        public DelegateCommand OpenCameraCommand { get; }

        #endregion Properties

        #region Constructor

        public PluginMediaPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
            this.OpenCameraCommand = new DelegateCommand(
                  async () => await OpenCameraExecute().ConfigureAwait(false));
        }

        #endregion Constructor

        #region Methods

        private async Task OpenCameraExecute()
        {
            await CrossMedia.Current.Initialize().ConfigureAwait(false);

            if (!CrossMedia.Current.IsCameraAvailable ||
                !CrossMedia.Current.IsTakePhotoSupported)
            {
                await this.PageDialogService.DisplayAlertAsync("取用相機", "沒有支援", "確定").ConfigureAwait(false);
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            }).ConfigureAwait(false);

            if (file == null)
                return;

            this.ImagePath = file.Path;

            this.Image = ImageSource.FromFile(file.Path);

            //await this.PageDialogService.DisplayAlertAsync("存檔路徑", file.Path, "OK").ConfigureAwait(false);

            //image.Source = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    return stream;
            //});
        }

        #endregion Methods
    }
}