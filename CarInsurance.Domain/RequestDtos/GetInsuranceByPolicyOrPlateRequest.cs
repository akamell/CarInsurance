namespace CarInsurance.Domain.RequestDtos
{
    public class GetInsuranceByPolicyOrPlateRequest
    {
        public string? Plate { get; set; }
        public string? Policy { get; set; }
    }
}
