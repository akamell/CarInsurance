namespace CarInsurance.Domain.Services
{
    public interface ICryptographyService
    {
        string GetHashPassword(string password, string salt);
        string GetSalt(int length);
    }
}
