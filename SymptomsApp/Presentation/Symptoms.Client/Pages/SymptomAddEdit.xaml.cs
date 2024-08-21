using Symptoms.ApiClient;
using Symptoms.ApiClient.Models.ApiModels;
using static Symptoms.ApiClient.Models.ApiModels.Symptom;

namespace Symptoms.Client.Pages;

public partial class SymptomAddEdit : ContentPage
{
    private readonly SymptomsApiClientService _apiClient;
    private readonly Symptom? _symptom;

    public SymptomAddEdit(SymptomsApiClientService apiClient, Symptom? symptom)
	{
		InitializeComponent();
        _apiClient = apiClient;
        _symptom = symptom;
        pickerPainType.ItemsSource = Enum.GetValues(typeof(PainTypes)).Cast<PainTypes>().ToList();
        LoadSymptomDetails();

    }

    private void LoadSymptomDetails()
    {
        if (_symptom is not null)
        {
            pickerPainType.SelectedItem = _symptom.PainType;
            txtSeverityScale.Text = _symptom.SeverityScale.ToString();
            txtSymptomDurationHours.Text = _symptom.SymptomDurationHours.ToString();
        }
    }

    private async void btnSave_Clicked(object sender, EventArgs e)
    {
        if (_symptom is null)
        {
            // Add a new product

            await _apiClient.SaveSymptom(new Symptom
            {
                PainType = (PainTypes)pickerPainType.SelectedItem,
                SeverityScale = int.Parse(txtSeverityScale.Text),
                SymptomDurationHours = int.Parse(txtSymptomDurationHours.Text)
            });
        }
        else
        {
            //Update an existing product

            await _apiClient.UpdateSymptom(new Symptom
            {
                Id = _symptom.Id,
                PainType = (PainTypes)pickerPainType.SelectedItem,
                SeverityScale = int.Parse(txtSeverityScale.Text),
                SymptomDurationHours = int.Parse(txtSymptomDurationHours.Text)
            });
        }

        await Navigation.PopModalAsync();
    }

    private async void btnCancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}