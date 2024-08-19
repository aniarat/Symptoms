using Symptoms.Client.Pages;

namespace Symptoms.Client
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = mainPage;
            MainPage = new NavigationPage(new SymptomListPage());
        }
    }
}
