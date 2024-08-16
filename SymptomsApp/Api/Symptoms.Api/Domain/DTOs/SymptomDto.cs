using MongoDB.Bson.Serialization.Attributes;

namespace Symptoms.Api.Domain.DTOs
{
    public class SymptomDto
    {
        [BsonElement("severity_scale"), BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public int SeverityScale { get; set; }

        [BsonElement("duration_hours"), BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public int? SymptomDurationHours { get; set; }
    }
}
