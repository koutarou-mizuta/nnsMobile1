using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace nnsMobile1
{
    public partial class App : Application
    {
        const string uwpKey = "2b977979-ebbc-40f8-b6d2-cddb98312ac1";
        const string iosKey = "625dde21-70d3-4c15-ab18-e9cf4ded77bc";
        const string androidKey = "fcfe18e6-3012-4d6f-bd98-ff3b25b69d82";

        public App(String mailaddr)
        {
            InitializeComponent();

            //MainPage = new MainPage(mailaddr);  Modalではiosでメーラーが起動しないので
            MainPage = new NavigationPage(new MainPage(mailaddr));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            // ANDROID AppCenter.Start("fcfe18e6-3012-4d6f-bd98-ff3b25b69d82", typeof(Analytics), typeof(Crashes));
            //         AppCenter.Start("625dde21-70d3-4c15-ab18-e9cf4ded77bc", typeof(Analytics), typeof(Crashes));

            AppCenter.Start($"uwp={uwpKey};android={androidKey};ios={iosKey};",
                            typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
