using AppFlurl.ViewModels;
using Xamarin.Forms;

namespace AppFlurl
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
