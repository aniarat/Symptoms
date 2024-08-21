using Symptoms.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symptoms.Client.Rules
{
    internal class SeverityScaleMustBeInteger : ISpecification<Symptom>
    {
        public string ErrorMessage { get; private set; }

        public bool IsSatisfiedBy(Symptom symptom)
        {
            if (!int.TryParse(symptom.SeverityScale.ToString(), out int severity))
            {
                ErrorMessage = "Severity scale must be a valid integer.";
                return false;
            }
            return true;
        }
    }
}
