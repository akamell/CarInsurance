using AutoFixture;
using CarInsurance.Domain.Services;
using CarInsurance.Controllers;
using CarInsurance.Domain.Dtos;
using CarInsurance.Domain.Entities;
using CarInsurance.Domain.RequestDtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CarInsurance.Test.Controllers
{
    public class InsuranceControllerTests
    {
        private readonly InsuranceController _sut;
        private readonly Fixture _fixture;
        private readonly Mock<IInsuranceService> _service;
        public InsuranceControllerTests() 
        {
            _fixture = new Fixture();
            _service = new Mock<IInsuranceService>();
            _sut = new InsuranceController(_service.Object);
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnListOfInsurances()
        {
            // arrange
            var result = new ResponsePackageDto<IEnumerable<Insurance>>();
            result.Result = _fixture.Create<List<Insurance>>();
            _service
                .Setup(x => x.GetInsurancesAsync())
                .Returns(Task.FromResult(result));
            // Act
            IActionResult response = await _sut.GetAll();
            OkObjectResult objectResults = (OkObjectResult)response;
            // Assert
            Assert.Equal(200, objectResults.StatusCode);
        }

        [Fact]
        public async Task Get_BadRequest_ReturnEmpty()
        {
            // arrange
            var result = new ResponsePackageDto<IEnumerable<Insurance>>();
            result.Result = null;
            _service
                .Setup(x => x.GetInsurancesAsync())
                .Returns(Task.FromResult(result));
            // Act
            IActionResult response = await _sut.GetAll();
            NotFoundResult objectResults = (NotFoundResult)response;
            // Assert
            Assert.Equal(404, objectResults.StatusCode);
        }

        [Fact]
        public async Task GetByPlate_OnSuccess_ReturnListOfInsurances()
        {
            // arrange
            var plate = "ABC123";
            var result = new ResponsePackageDto<IEnumerable<Insurance>>();
            var insurances = _fixture.Create<List<Insurance>>();
            insurances.Add(new Insurance
            {
                Vehicle = new Vehicle { Plate = plate }
            });
            result.Result = insurances;

            _service
                .Setup(x => x.GetInsuranceByPlateOrPolicy(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(result));

            var request = new GetInsuranceByPolicyOrPlateRequest
            {
                Plate = plate
            };

            // Act
            var response = await _sut.GetByPlateOrPolicy(request);
            OkObjectResult objectResults = (OkObjectResult)response;
            // Assert
            Assert.Equal(200, objectResults.StatusCode);
        }
    }
}
