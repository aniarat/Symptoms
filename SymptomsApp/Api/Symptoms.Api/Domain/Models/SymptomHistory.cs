using MongoDB.Bson.Serialization.Attributes;

namespace Symptoms.Api.Domain.Models
{
    public class SymptomHistory
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }


        public string SymptomId { get; set; }

        public string FieldName { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
