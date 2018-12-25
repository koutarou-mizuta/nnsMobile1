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
		public WebPage (string strUrl)
		{
			InitializeComponent ();

            webView.Source = strUrl;
        }

        private void BtnBack_Clicked(object sender, EventArgs e)
        {
            webView.GoBack();
        }
    }
}