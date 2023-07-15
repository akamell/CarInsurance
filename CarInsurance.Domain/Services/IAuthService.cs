using CarInsurance.Domain.Dtos;

namespace CarInsurance.Domain.Services
{
    public interface IAuthService
    {
        public string GetToken(NewTokenDto newTokenDto);
    }
}
