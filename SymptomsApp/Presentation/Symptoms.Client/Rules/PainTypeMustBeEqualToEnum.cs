using Symptoms.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symptoms.Client.Rules
{
    internal class PainTypeMustBeEqualToEnum : ISpecification
    {
        private readonly string _painTypeName;

        public PainTypeMustBeEqualToEnum(string painTypeName)
        {
            if (!Enum.IsDefined(typeof(Symptom.PainTypes), painTypeName))
            {
                throw new ArgumentException("Invalid PainType name.", nameof(painTypeName));
            }
            _painTypeName = painTypeName;
        }

        public bool IsSatisfiedBy(Symptom symptom)
        {
            return symptom.PainType.ToString() == _painTypeName;
        }

        
    }
}
