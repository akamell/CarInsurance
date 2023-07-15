using CarInsurance.Application.Services;
using CarInsurance.Domain.Dtos;
using CarInsurance.Domain.Entities;
using CarInsurance.Infrastructure.Persistences;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarInsurance.Infrastructure.Services
{
    public class InsuranceMongoService : MongoService<Insurance>, IPersistenceService<Insurance>, IInsuranceService
    {
        private readonly IMongoCollection<Insurance>? _insuranceCollection;
        public InsuranceMongoService(
            IOptions<MongoStoreDatabaseSettings> mongoStoreDatabaseSettings
        ) : base(mongoStoreDatabaseSettings, "Insurances") 
        {
            _insuranceCollection = GetInstanceCollection();
        }

        public async Task<ResponsePackageDto<IEnumerable<Insurance>>> GetInsurancesAsync()
        {
            var response = new ResponsePackageDto<IEnumerable<Insurance>>();
            response.Result = await GetAsync();
            return response;
        }

        public async Task<ResponsePackageDto<IEnumerable<Insurance>>> GetInsuranceByPlateOrPolicy(string? plate, string? policyNumber)
        {
            var response = new ResponsePackageDto<IEnumerable<Insurance>>();
            var insurances = await _insuranceCollection.FindAsync(x => x.PolicyNumber == policyNumber || x.Vehicle.Plate == plate);
            response.Result = await insurances.ToListAsync();
            return response;
        }

        public async Task<ResponsePackageDto<Insurance>> CreateInsurnace(Insurance insurance)
        {
            var response = new ResponsePackageDto<Insurance>();
            await CreateAsync(insurance);
            return response;
        }
    }
}
