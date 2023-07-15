using Microsoft.Extensions.Configuration;
using CarInsurance.Domain.Dtos;
using CarInsurance.Domain.RequestDtos;
using CarInsurance.Domain.Services;

namespace CarInsurance.Application.Services
{
    public class LoginService : ILoginService
    {
        public readonly IAuthService _authService;
        private readonly IConfiguration _configuration;
        public LoginService(
            IConfiguration configuration,
            IAuthService authService
        ) {
            _configuration = configuration;
            _authService = authService;
        }
        public ResponsePackageDto<string> DoAuthentication(LoginRequest request)
        {
            var response = new ResponsePackageDto<string>();

            // TO DO: auth users

            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = _configuration["Jwt:Key"];
            var metaDataToken = new NewTokenDto
            {
                Audience = audience,
                Issuer = issuer,
                Key = key,
                ExpiresInMinutes = 60,
                UserName = request.Username
            };
            var token = _authService.GetToken(metaDataToken);
            response.Result = token;
            return response;
        }
    }
}
