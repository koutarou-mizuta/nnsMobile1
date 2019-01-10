using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace nnsMobile1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //img_mail.Source = ImageSource.FromResource("nnsMobile1.Images.btn_mail.png");
            //img_point.Source = ImageSource.FromResource("nnsMobile1.Images.btn_mail.png");
            //img_shopping.Source = ImageSource.FromResource("nnsMobile1.Images.btn_mail.png");

        }

        private void BtnMessage_Clicked(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }

        void BtnPoint_Clicked(object sender, System.EventArgs e)
        {
            String strUrl = "http://mobile.fishing-try.com/mobile/s/sTop.aspx?adr=koutarou.mizuta@findtech.jp";
            this.Navigation.PushModalAsync(new WebPage(strUrl));
            // this.Navigation.PushAsync(new WebPage(strUrl));
        }

        private void BtnToRegist_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new CallMailer());
        }
    }
}
