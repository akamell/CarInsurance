using CarInsurance.Domain.Entities;
using FluentValidation;
using System;

namespace CarInsurance.Application.Validations
{
    public class CreateInsuranceValidator : AbstractValidator<Insurance>
    {
        public CreateInsuranceValidator()
        {
            var date = DateTime.UtcNow.Date;
            RuleFor(x => x.StartDate)
                .NotEmpty()
                .LessThan(x => x.EndDate)
                .WithMessage(x => $"Fecha de inicio de la poliza debe ser menor a la fecha de finalizacion");

            RuleFor(x => x.EndDate)
                .NotEmpty()
                .GreaterThanOrEqualTo(date)
                .WithMessage(x => $"Fecha de finalización de la poliza debe ser mayor o igual al dia actual");

            RuleFor(x => x.MaxCoverageAmount)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage(x => $"Valor maximo de cobertura debe ser mayor a 0");

            RuleFor(x => x.Vehicle)
                .NotEmpty()
                .WithMessage(x => $"Se debe enviar informacion de vehiculo");

            RuleFor(x => x.Client)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Must((x) => x.ClientId != null)
                .WithMessage(x => $"Se debe enviar informacion de cliente");
        }
    }
}
