using CarInsurance.Domain.Dtos;
using CarInsurance.Domain.RequestDtos;

namespace CarInsurance.Domain.Services
{
    public interface ILoginService
    {
        ResponsePackageDto<string> DoAuthentication(LoginRequest request);
    }
}
