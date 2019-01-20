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
        public MainPage(String mailaddr)
        {
            InitializeComponent();

            //img_mail.Source = ImageSource.FromResource("nnsMobile1.Images.btn_mail.png");
            //img_point.Source = ImageSource.FromResource("nnsMobile1.Images.btn_mail.png");
            //img_shopping.Source = ImageSource.FromResource("nnsMobile1.Images.btn_mail.png");

            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fileName = fileName = path + "/kmfccd.txt";
            string cd = "";

            if (System.IO.File.Exists(fileName))
            {
                cd = System.IO.File.ReadAllText(fileName);
            }

            fileName = path + "/barcode.jpg";
            if (System.IO.File.Exists(fileName))
            {
                //ﾊﾞｰｺｰﾄﾞﾌｧｲﾙが在ったら 登録済み
                this.imgBarCode.IsVisible = true;
                this.imgBarCode.Source = ImageSource.FromFile(fileName);
                this.btnToRegist.IsVisible = false;
                this.lblKmfCd.Text = "会員番号 " + cd;
            }
            else
            {
                this.imgBarCode.IsVisible = false;
                this.btnToRegist.IsVisible = true;
                this.lblKmfCd.Text = "仮の会員番号 " + cd;
            }

            if (mailaddr != null)
            {
                this.Navigation.PushAsync(new Regist(mailaddr));
            }





        }

        private void BtnToRegist_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new CallMailer());
        }

        private void BtnMessage_Clicked(object sender, System.EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void BtnPoint_Clicked(object sender, System.EventArgs e)
        {
            String strUrl = "http://mobile.fishing-try.com/mobile/s/sTop.aspx?adr=koutarou.mizuta@findtech.jp";
            this.Navigation.PushAsync(new WebPage(strUrl));
        }

        private void BtnOnlineShop_Clicked(object sender, EventArgs e)
        {
            String strUrl = "http://mobile.fishing-try.com/mobile/";
            this.Navigation.PushModalAsync(new WebPage(strUrl));

        }

        private void BtnShopInfo_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnBlog_Clicked(object sender, EventArgs e)
        {

        }
    }
}
