using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace XamlInteg.ViewModels
{
    public class SfPdfViewerContentPageViewModel : ViewModelBase
    {
        #region Fields

        private Stream pdfDocumentStream;

        #endregion Fields

        #region Properties

        public Stream PdfDocumentStream { get => pdfDocumentStream; set => SetProperty(ref pdfDocumentStream, value); }

        #endregion Properties

        #region Constructor

        public SfPdfViewerContentPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
        }

        #endregion Constructor

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            //PdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("XamlInteg.Assets.Xamarin Forms Succinctly.pdf");

            var url = "https://www.shin-her.com.tw/news/%E4%BA%BA%E5%8A%9B%E8%B3%87%E6%BA%90%E7%B6%B2%E4%B8%8A%E5%82%B3%E8%AA%AA%E6%98%8E%E6%96%87%E4%BB%B6.pdf";
            var result = await DownloadPdfStream(url);
            PdfDocumentStream = result;
        }

        private async Task<Stream> DownloadPdfStream(string URL)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(URL);
            //Check whether redirection is needed
            if ((int)response.StatusCode == 302)
            {
                //The URL to redirect is in the header location of the response message
                HttpResponseMessage redirectedResponse = await httpClient.GetAsync(response.Headers.Location.AbsoluteUri);
                return await redirectedResponse.Content.ReadAsStreamAsync();
            }
            return await response.Content.ReadAsStreamAsync();
        }
    }
}