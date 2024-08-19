using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symptoms.Client.Models
{
    internal class Symptom
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public PainTypes PainType { get; set; }

        public int SeverityScale { get; set; }

        public decimal? SymptomDurationHours { get; set; }

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
