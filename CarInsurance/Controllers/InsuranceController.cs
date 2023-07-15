using CarInsurance.Domain.Services;
using CarInsurance.Domain.Dtos;
using CarInsurance.Domain.Entities;
using CarInsurance.Domain.RequestDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CarInsurance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponsePackageDto<IEnumerable<Insurance>>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponsePackageDto<IEnumerable<Insurance>>))]
        public async Task<IActionResult> GetAll()
        {
            var result = await _insuranceService.GetInsurancesAsync();
            if (result.Result == null && result.Errors is null) return NotFound();
            return result.Errors is null ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        [Route("by/plate-or-policy")]
        public async Task<IActionResult> GetByPlateOrPolicy([FromQuery] GetInsuranceByPolicyOrPlateRequest request)
        {
            var result = await _insuranceService.GetInsuranceByPlateOrPolicy(request.Plate, request.Policy);
            if (result.Result == null && result.Errors is null) return NotFound();
            return result.Errors is null ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Insurance insurance)
        {
            var result = await _insuranceService.CreateInsurnace(insurance);
            return result.Errors is null ? Ok(result) : BadRequest(result);
        }
    }
}