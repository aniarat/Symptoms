using MongoDB.Bson.Serialization.Attributes;

namespace Symptoms.Api.Domain.Models
{
    public class SymptomHistory
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("symptom_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? SymptomId { get; set; }

        [BsonElement("field_name"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? FieldName { get; set; }
        
        [BsonElement("old_value"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? OldValue { get; set; }

        [BsonElement("new_value"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? NewValue { get; set; }

        [BsonElement("modified_date"), BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime ModifiedDate { get; set; }
        
    }
}
