﻿using Symptoms.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symptoms.Client.Rules
{
    internal class PainTypeMustBeEqualToEnum : ISpecification<Symptom>
    {
        public string ErrorMessage { get; private set; }

        public bool IsSatisfiedBy(Symptom symptom)
        {
            // Sprawdzenie, czy wartość PainType jest prawidłowa
            if (!Enum.IsDefined(typeof(Symptom.PainTypes), symptom.PainType))
            {
                ErrorMessage = "Invalid PainType. The value must be one of the predefined PainTypes.";
                return false;
            }

            return true;
        } 


    }
}
