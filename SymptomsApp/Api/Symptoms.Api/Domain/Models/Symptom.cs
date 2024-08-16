using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Symptoms.Api.Domain.Models
{
    public class Symptom
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("created_at"), BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [BsonElement("pain_type"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [Required(ErrorMessage = "PainType must be specified.")]
        public PainTypes PainType { get; set; }

        [BsonElement("severity_scale"), BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        [Range(1, 10, ErrorMessage = "Severity scale must be a number between 1 and 10.")]
        public int SeverityScale { get; set; }

        [BsonElement("duration_hours"), BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public int? SymptomDurationHours { get; set; }

        [BsonElement("occurence_counter"), BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public int OccurrenceCounter { get; set; }


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
