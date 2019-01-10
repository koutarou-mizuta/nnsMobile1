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
	public partial class CallMailer : ContentPage
	{
		public CallMailer ()
		{
			InitializeComponent ();
		}

        private void BtnMail_Clicked(object sender, EventArgs e)
        {
            string errMsg = String.Empty;
            //DependencyService.Get<IMailService>().StartMailer("タイトル", "本文", null, null, null, this.txtFilePath, ref errMsg);
            DependencyService.Get<IMailService>().StartMailer("タイトル", "本文", null, null, null, null, ref errMsg);
            if (String.IsNullOrEmpty(errMsg))
            {
                this.DisplayAlert("メール送信完了",
                                        "メール送信完了しました。" + System.Environment.NewLine +
                                        errMsg, "OK");
            }
            else
            {
                this.DisplayAlert("メール送信失敗",
                                        "メールが送信できませんでした。" + System.Environment.NewLine +
                                        errMsg, "OK");

            }
            this.Navigation.PopModalAsync();
            //var intent = new Intent();
            //intent.SetAction(Intent.ActionSend);
            //intent.SetType("text/plain");
            //intent.PutExtra(Intent.ExtraEmail, new String[] { "user1@example.com" });
            //intent.PutExtra(Intent.ExtraCc, new String[] { "user2@example.com" });
            //intent.PutExtra(Intent.ExtraBcc, new String[] { "user3@example.com" });
            //intent.PutExtra(Intent.ExtraSubject, "件名");
            //intent.PutExtra(Intent.ExtraText, "本文");
            //StartActivity(intent);


        }
    }
}