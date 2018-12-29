using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace nnsMobile1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WebPage : ContentPage
	{
        public WebPage()
        {
            InitializeComponent();
            //String strUrl = "http://mobile.fishing-try.com/mobile/s/sTop.aspx?adr=koutarou.mizuta@findtech.jp";
            //String strUrl = "https://www.yahoo.co.jp/";
            // webView.Source = strUrl;

        }

        public WebPage (string strUrl) : this()
		{
			//InitializeComponent ();

            webView.Source = strUrl;
        }

        private void BtnBack_Clicked(object sender, EventArgs e)
        {        
            if (webView.CanGoBack)
            {
                webView.GoBack();
            }
            else
            {
                this.Navigation.PopModalAsync();
            }

        }
        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

    }
}