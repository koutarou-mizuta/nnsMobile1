using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using System.IO;

namespace nnsMobile1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Regist : ContentPage
	{
		public Regist (String mailaddr)
		{
			InitializeComponent ();

            if (mailaddr != null && mailaddr.IndexOf('@') > 0 )
            {
                this.lblMailAddr.Text = mailaddr;
            }

            this.lblKmfCd.Text = "654010824";
        }

        private void BtnRegist_Clicked(object sender, EventArgs e)
        {

            string result = "-1";
            string item;
            string userName = FirstName.Text + " " + LastName.Text;

            //Indicator.IsRunning = true;

            item = "Token=" + "" + "&Ccd=" + lblKmfCd.Text + "&Name=" + userName + "&Sex=1" + "&Tel=" + PassWord.Text + "&Mail=k.mizu12@gmail.com";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("http://61.199.58.74/MyWebApi/");
                client.DefaultRequestHeaders.Accept.Clear();

                result = client.GetStringAsync("api/values/?" + item).Result;
                //Log.Debug(TAG, "http result: " + result);
            }

            if (result == "1")
            {
                string uri = "http://61.199.58.74/js/barcode/0000000001.jpg";
                downloadFileAsync(uri);

                this.Navigation.PopModalAsync(true);

            }
        }

        private async void downloadFileAsync(string uri)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fileName = path + "/barcode.jpg";

            var client = new HttpClient();
            HttpResponseMessage res = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);

            using (var fileStream = File.Create(fileName))
            {
                using (var httpStream = await res.Content.ReadAsStreamAsync())
                {
                    httpStream.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }
        }



    }
}