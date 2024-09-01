using MongoDB.Bson.Serialization.Attributes;

namespace Symptoms.Api.Domain.DTOs
{
    public class SymptomDto
    {
        [BsonElement("severity_scale"), BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public int SeverityScale { get; set; }

        [BsonElement("start_date_time"), BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime StartDateTime { get; set; }

        [BsonElement("end_date_time"), BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime? EndDateTime { get; set; }

        // Duration will be computed based on StartDateTime and EndDateTime
        [BsonIgnore]
        public decimal? SymptomDurationHours
        {
            get
            {
                if (EndDateTime.HasValue)
                {
                    var duration = EndDateTime.Value - StartDateTime;
                    return (decimal)duration.TotalHours;
                }
                return null; // Time duration will be null if EndDateTime is not provided
            }
        }
        //[BsonElement("duration_hours"), BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        //public decimal? SymptomDurationHours { get; set; }
    }
}
