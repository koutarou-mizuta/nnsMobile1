using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace nnsMobile1.Droid
{
    [Activity(Label = "nnsMobile1", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [IntentFilter(
      actions: new[] { Intent.ActionView }
      , Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable }
      , DataHost = "jp.findtech"
      , DataScheme = "myapp"
     )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            String mailaddr = null;
            var intent = this.Intent;
            if (Intent.ActionView.Equals(intent.Action))
            {
                var uri = intent.Data;
                // uri: myapp://jp.findtech/comment/view/801
                // uri: myapp://jp.findtech?adr=k.mizu12@gmail.com
                if (uri != null)
                {
                    mailaddr = uri.GetQueryParameter("adr");

                    // 渡ってきたURLをスラッシュ区切りでリストにして, それを表示させて確認
                    //uri.PathSegments
                    //    .ToList()
                    //    .ForEach(Console.WriteLine);

                    // "hogeapp://main?param1=aabbcc&hoge=fuga&xyz=1000" で起動されていれば
                    // ここでは "aabbcc" という文字列が取得できる。
                    //string param1 = uri.GetQueryParameter("param1");
                }
            }
            LoadApplication(new App(mailaddr));

        }


    }
}