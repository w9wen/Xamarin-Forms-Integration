using Prism.Commands;
using Prism.Mvvm;
using System;
using System.IO;
using Xamarin.Essentials;

namespace XamlInteg.ViewModels
{
    public class EssentialFileSystemHelperPageViewModel : BindableBase
    {
        #region Fields

        private string appPackageFileContent;

        private const string appPackageFileName = "FileSystemTemplate.txt";

        #endregion Fields

        #region Properties

        public string AppPackageFileContent
        {
            get => appPackageFileContent;
            set => SetProperty(ref appPackageFileContent, value);
        }

        public DelegateCommand SaveCommand { get; }
        public DelegateCommand OpenAppPackageFileCommand { get; }

        #endregion Properties

        #region Constructor

        public EssentialFileSystemHelperPageViewModel()
        {
            SaveCommand = new DelegateCommand(SaveExecute);
            OpenAppPackageFileCommand = new DelegateCommand(OpenAppPackageFileExecute);
        }

        #endregion Constructor

        #region Methods

        private void SaveExecute()
        {
            throw new NotImplementedException();
        }

        private async void OpenAppPackageFileExecute()
        {
            using (var stream = await FileSystem.OpenAppPackageFileAsync(appPackageFileName))
            {
                using (var reader = new StreamReader(stream))
                {
                    AppPackageFileContent = await reader.ReadToEndAsync();
                }
            }
        }

        #endregion Methods
    }
}