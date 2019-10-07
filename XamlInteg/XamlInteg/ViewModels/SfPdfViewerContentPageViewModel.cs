using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
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

        public SfPdfViewerContentPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }

        #endregion Constructor

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            //PdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("XamlInteg.Assets.Xamarin Forms Succinctly.pdf");

            var url = "sample-url";
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