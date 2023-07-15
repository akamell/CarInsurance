using CarInsurance.Domain.Services;
using CarInsurance.Domain.Dtos;
using CarInsurance.Domain.RequestDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarInsurance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        public readonly ILoginService _loginService;

        public AuthController(ILoginService loginService) 
        {
            _loginService = loginService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponsePackageDto<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponsePackageDto<string>))]
        public IActionResult Authentication(LoginRequest request)
        {
            var response = _loginService.DoAuthentication(request);
            return Ok(response);
        }

    }
}