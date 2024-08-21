using Symptoms.ApiClient;
using Symptoms.ApiClient.Models.ApiModels;
using Symptoms.Client.Pages;

namespace Symptoms.Client
{
    public partial class MainPage : ContentPage
    {
        private readonly SymptomsApiClientService _apiClient;

        public MainPage(SymptomsApiClientService apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new SymptomAddEdit(_apiClient, null));
            try
            {
                await Navigation.PushModalAsync(new SymptomAddEdit(_apiClient, null));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error navigating to SymptomAddEdit: {ex.Message}");
                await DisplayAlert("Error", "An error occurred while navigating.", "OK");
            }

        }

        private async void btnShowSymptoms_Clicked(object sender, EventArgs e)
        {
            await LoadSymptoms();
        }

        private async void symptomsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var symptom = (Symptom)e.Item;
            var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

            switch (action)
            {
                case "Edit":
                    await Navigation.PushModalAsync(new SymptomAddEdit(_apiClient, symptom));
                    break;
                case "Delete":
                    await _apiClient.DeleteSymptom(symptom.Id);
                    await LoadSymptoms();
                    break;
            }
        }

        private async Task LoadSymptoms()
        {
            var symptoms = await _apiClient.GetSymptoms();
            symptomsListView.ItemsSource = symptoms;
        }

    }

}
