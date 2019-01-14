using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using Foundation;
//using UIKit;

using Foundation;
using UIKit;
using MessageUI;
using Xamarin.Forms;
//using AppName.iOS.Services;
//using AppName.Services;

[assembly: Dependency(typeof(nnsMobile1.iOS.MailService))]

namespace nnsMobile1.iOS
{
        public class MailService : IMailService
        {
            public bool StartMailer(string title, string body, string[] to, string[] cc, string[] bcc, string filePath, ref string err)
            {
                //初期化
                err = String.Empty;
                string ret = String.Empty;

                if (!MFMailComposeViewController.CanSendMail)
                {//メール送信が可能かどうかの確認
                    err = "この端末はメールが送信可能な状態にありません。";
                    return false; //メール送信不能
                }

                var mail = new MFMailComposeViewController();//インスタンスの生成

                //項目セット
                if (to != null && to.Length > 0)
                {
                    mail.SetToRecipients(to);
                }
                if (cc != null && cc.Length > 0)
                {
                    mail.SetCcRecipients(cc);
                }
                if (bcc != null && bcc.Length > 0)
                {
                    mail.SetBccRecipients(bcc);
                }
                mail.SetSubject(title);
                mail.SetMessageBody(body, false);

                /*
                if (!String.IsNullOrEmpty(filePath))
                {
                    //ファイル添付あり

                    //拡張子
                    string extention = System.IO.Path.GetExtension(filePath.ToLower()).Replace(".", "");
                    if (String.IsNullOrEmpty(extention))
                    {
                        //拡張子が取得できない場合はテキストで開く
                        extention = "txt";
                    }
                    //mime type
                    string mimetype = MimeTypeUtility.GetMimeType(extention);

                    NSData data = NSData.FromFile(filePath);
                    mail.AddAttachmentData(data, mimetype, System.IO.Path.GetFileName(filePath));
                }
                */

                mail.Finished += (o, args) => {
                    //送信処理終了時のイベント
                    ret = args.Result.ToString(); //　srgs.Result:戻り値
                    args.Controller.DismissViewController(true, null); //Eメール画面の消去
                };

                //メーラー起動
                var view = UIApplication.SharedApplication.KeyWindow.RootViewController;
                view.PresentViewController(mail, true, null);
                err = ret;
                return true;
            }
        }
}