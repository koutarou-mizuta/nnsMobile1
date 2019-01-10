//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;

using System;
using Android.Content;
using Xamarin.Forms;

[assembly: Dependency(typeof(nnsMobile1.Droid.MailService))]

namespace nnsMobile1.Droid
{
    class MailService : IMailService
    {
        public bool StartMailer(string title, string body, string[] to, string[] cc, string[] bcc, string filePath, ref string err)
        {
            try
            {
                //初期化
                err = String.Empty;

                var intent = new Intent();

                //アクションにACTION_SENDを指定して暗黙的インテントを呼び出すことで、
                //インストールされているアプリで対応可能なものが列挙されます。
                intent.SetAction(Intent.ActionSend);
                intent.AddFlags(ActivityFlags.NewTask);

                //項目セット
                intent.SetData(Android.Net.Uri.Parse("mailto:" + to));
                if (to != null && to.Length > 0)
                {
                    intent.PutExtra(Intent.ExtraEmail, to);
                }
                if (cc != null && cc.Length > 0)
                {
                    intent.PutExtra(Intent.ExtraCc, cc);
                }
                if (bcc != null && bcc.Length > 0)
                {
                    intent.PutExtra(Intent.ExtraBcc, bcc);
                }
                intent.PutExtra(Intent.ExtraSubject, title);
                intent.PutExtra(Intent.ExtraText, body);

                if (String.IsNullOrEmpty(filePath))
                {
                    //ファイル添付なし
                    //intent.SetType("text/plain");
                    intent.SetType("message/rfc822");
                }
                else
                {
                    //ファイル添付あり
                    intent.SetType("message/rfc822");
                    Java.IO.File sendFile = new Java.IO.File(filePath);
                    intent.PutExtra(Intent.ExtraStream, Android.Net.Uri.FromFile(sendFile));
                }

                //メーラー起動
#pragma warning disable CS0618 // 型またはメンバーが古い形式です
                Forms.Context.StartActivity(intent);
#pragma warning restore CS0618 // 型またはメンバーが古い形式です

            }
            catch (Exception ex)
            {
                err = ex.Message;
                Console.WriteLine(ex.Message + System.Environment.NewLine + ex.StackTrace);
                return false;
            }
            return true;
        }
    }


}
