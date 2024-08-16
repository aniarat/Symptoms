using System;
using System.Collections.Generic;
using System.Text;

namespace Symptoms.ApiClient.Models.ApiModels
{
    public class SymptomHistory
    {
        public string Id { get; set; }

        public string SymptomId { get; set; }

        public string FieldName { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
