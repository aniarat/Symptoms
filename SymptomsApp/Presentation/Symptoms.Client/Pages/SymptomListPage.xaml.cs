using Symptoms.Client.Models;
using Symptoms.Client.Models.ViewModels;

namespace Symptoms.Client.Pages;

public partial class SymptomListPage : ContentPage
{
	public SymptomListPage()
	{
		InitializeComponent();
        BindingContext = new SymptomsViewModel();
    }
    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var symptom = (Symptom)e.Item;
        var symptomDetailViewModel = new SymptomDetailViewModel { Symptom = symptom };
        var symptomDetailPage = new SymptomDetailPage();
        symptomDetailPage.BindingContext = symptomDetailViewModel;

        Navigation.PushAsync(symptomDetailPage);
    }
}