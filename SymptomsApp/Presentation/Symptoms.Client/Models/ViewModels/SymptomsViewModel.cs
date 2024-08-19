using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Symptoms.Client.Models.Symptom;

namespace Symptoms.Client.Models.ViewModels
{
    internal partial class SymptomsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Symptom> symptoms = new();

        [ObservableProperty]
        private Symptom symptom = new();

        public List<PainTypes> PainTypeList { get; } = Enum.GetValues(typeof(PainTypes)).Cast<PainTypes>().ToList();


        [RelayCommand]
        private void Add()
        {
            Symptoms.Add(Symptom);
            Symptom = new();
        }
    }
}
