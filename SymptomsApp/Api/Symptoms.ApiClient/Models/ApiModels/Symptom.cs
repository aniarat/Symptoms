using System;
using System.Collections.Generic;
using System.Text;

namespace Symptoms.ApiClient.Models.ApiModels
{
    public class Symptom
    {
        public string? Id { get; set; }

        public DateTime CreatedAt { get; set; }


        public PainTypes PainType { get; set; }


        public int SeverityScale { get; set; }

        public int? SymptomDurationHours { get; set; }

        public int OccurrenceCounter { get; set; }


        public enum PainTypes
        {
            Headache,
            Stomachache,
            BackPain,
            AbdominalPain,
            ChestPain,
            MusclePain
        }
    }
}
