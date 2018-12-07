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

            img_mail.Source = ImageSource.FromResource("nnsMobile1.Images.btn_mail.png");
            img_point.Source = ImageSource.FromResource("nnsMobile1.Images.btn_mail.png");
            img_shopping.Source = ImageSource.FromResource("nnsMobile1.Images.btn_mail.png");
        }
    }
}
