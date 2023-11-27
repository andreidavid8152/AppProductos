using MauiApp1.Service;

namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            APIService _APIService = new APIService();
            MainPage = new NavigationPage(new ProductoPage(_APIService));
        }
    }
}