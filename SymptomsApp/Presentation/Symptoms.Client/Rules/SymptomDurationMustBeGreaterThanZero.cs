﻿using Symptoms.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symptoms.Client.Rules
{
    internal class SymptomDurationMustBeGreaterThanZero : ISpecification<Symptom>
    {
        private readonly decimal _minHours;

        public SymptomDurationMustBeGreaterThanZero(decimal minHours)
        {
            if (minHours <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minHours), "must be greater than 0.");
            }
            _minHours = minHours;
        }

        public string ErrorMessage => throw new NotImplementedException();

        public bool IsSatisfiedBy(Symptom symptom)
        {
            return symptom.SymptomDurationHours.HasValue && symptom.SymptomDurationHours.Value > _minHours;
        }
    }
}
