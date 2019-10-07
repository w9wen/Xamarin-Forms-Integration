using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace XamlInteg.ViewModels
{
    public class SfPdfViewerPageViewModel : BindableBase
    {
        private Stream pdfDocumentStream;

        public Stream PdfDocumentStream { get => pdfDocumentStream; set => pdfDocumentStream = value; }

        public SfPdfViewerPageViewModel()
        {
            PdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("XamlInteg.Assets.Xamarin Forms Succinctly.pdf");
        }
    }
}