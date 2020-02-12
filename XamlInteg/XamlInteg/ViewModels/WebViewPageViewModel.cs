using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamlInteg.ViewModels
{
    public class WebViewPageViewModel : BindableBase
    {
        private Uri webViewUrl;

        public Uri WebViewUrl { get => webViewUrl; set => SetProperty(ref webViewUrl, value); }

        public WebViewPageViewModel()
        {
            try
            {
                this.WebViewUrl = new Uri(@"https://demo.shin-her.com.tw/tnvs/ICampus/");
            }
            catch (Exception ex)
            {
            }
        }
    }
}