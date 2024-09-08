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

        [BsonElement("start_date_time"), BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        [Required(ErrorMessage = "StartDateTime must be specified.")]
        public DateTime StartDateTime { get; set; }

        [BsonElement("end_date_time"), BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime? EndDateTime { get; set; }

        [BsonElement("duration_hours"), BsonRepresentation(MongoDB.Bson.BsonType.Double)]
        public decimal? SymptomDurationHours
        {
            get
            {
                if (EndDateTime.HasValue)
                {
                    var duration = EndDateTime.Value - StartDateTime;
                    return (decimal)duration.TotalHours;
                }
                return null; 
            }
        }

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
