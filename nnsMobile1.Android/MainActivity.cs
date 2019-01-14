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
                // uri: myapp://example.jp/comment/view/801

                if (uri != null)
                {
                    mailaddr = "k.mizu12@gmail.com";


                    // 渡ってきたURLをスラッシュ区切りでリストにして, それを表示させて確認
                    //uri.PathSegments
                    //    .ToList()
                    //    .ForEach(Console.WriteLine);
                }
            }

            LoadApplication(new App(mailaddr));


        }

        //protected override void OnResume()
        //{
        //    base.OnResume();

        //    var intent = this.Intent;

        //    if (Intent.ActionView.Equals(intent.Action))
        //    {
        //        var uri = intent.Data;
        //        // uri: myapp://example.jp/comment/view/801

        //        if (uri != null)
        //        {



        //            // 渡ってきたURLをスラッシュ区切りでリストにして, それを表示させて確認
        //            //uri.PathSegments
        //            //    .ToList()
        //            //    .ForEach(Console.WriteLine);
        //        }
        //    }
        //}


    }
}