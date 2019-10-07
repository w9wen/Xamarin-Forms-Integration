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
        #region Fields

        private Stream pdfDocumentStream;

        #endregion Fields

        #region Properties

        public Stream PdfDocumentStream { get => pdfDocumentStream; set => pdfDocumentStream = value; }

        #endregion Properties

        #region Constructor

        public SfPdfViewerPageViewModel()
        {
            PdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("XamlInteg.Assets.Xamarin Forms Succinctly.pdf");
        }

        #endregion Constructor
    }
}