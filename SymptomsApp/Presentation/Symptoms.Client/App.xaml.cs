using Symptoms.Client.Pages;

namespace Symptoms.Client
{
    public partial class App : Application
    {
        private Page? mainPage;

        public App(MainPage mainPage)
        {
            InitializeComponent();

            MainPage = mainPage;
            //MainPage = new NavigationPage(new SymptomListPage());
        }
    }
}
