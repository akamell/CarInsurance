using CarInsurance.Domain.Dtos;
using CarInsurance.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarInsurance.Domain.Services
{
    public interface IInsuranceService
    {
        Task<ResponsePackageDto<IEnumerable<Insurance>>> GetInsurancesAsync();
        Task<ResponsePackageDto<IEnumerable<Insurance>>> GetInsuranceByPlateOrPolicy(string? plate, string? policyNumber);
        Task<ResponsePackageDto<Insurance>> CreateInsurnace(Insurance insurance);
    }
}
