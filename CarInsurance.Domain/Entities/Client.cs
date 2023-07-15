using System;

namespace CarInsurance.Domain.Entities
{
    public class Client
    {
        public string ClientId { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public DateTime? Birthday { get; set; }
        public string? CityAddress { get; set; }
        public string? Address { get; set; }
    }
}
