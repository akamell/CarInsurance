using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace CarInsurance.Domain.Entities
{
    public class Insurance
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string PolicyNumber { get; set; } = null!;
        public DateTime PolicyDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal MaxCoverageAmount { get; set; }
        public Client Client { get; set; } = null!;
        public Vehicle Vehicle { get; set; } = null!;
        public bool HasInspection { get; set; }
    }
}
