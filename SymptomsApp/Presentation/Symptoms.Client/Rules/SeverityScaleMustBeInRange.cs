using Symptoms.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symptoms.Client.Rules
{
    internal class SeverityScaleMustBeInRange : ISpecification
    {

        private readonly int _severity;

        public SeverityScaleMustBeInRange(int severity)
        {
            if (severity < 1 || severity > 10)
            {
                throw new ArgumentOutOfRangeException("Severity must be between 1 and 10.");
            }
            _severity = severity;
        }
        public bool IsSatisfiedBy(Symptom symptom)
        {
            return symptom.SeverityScale == _severity;

        }
    }
}
