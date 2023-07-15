namespace CarInsurance.Domain.Dtos
{
    public class NewTokenDto
    {
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public string Key { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public int ExpiresInMinutes { get; set; }
    }
}
