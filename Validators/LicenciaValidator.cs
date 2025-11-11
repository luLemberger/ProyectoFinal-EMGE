using FluentValidation;
using LicenciasAPI.Models;

namespace LicenciasAPI.Validators
{
    public class LicenciaValidator : AbstractValidator<Licencia>
    {
        public LicenciaValidator()
        {
            RuleFor(x => x.DNI)
                .NotEmpty().WithMessage("El DNI es obligatorio.")
                .Length(8, 9).WithMessage("El DNI debe tener entre 8 y 9 caracteres.");

            RuleFor(x => x.Tipo)
                .NotEmpty().WithMessage("El tipo de licencia es obligatorio.");

            RuleFor(x => x.Provincia)
                .NotEmpty().WithMessage("La provincia es obligatoria.");

            RuleFor(x => x.Localidad)
                .NotEmpty().WithMessage("La localidad es obligatoria.");

            RuleFor(x => x.Direccion)
                .NotEmpty().WithMessage("La dirección es obligatoria.");

            RuleFor(x => x.OrdenDelDia)
                .NotEmpty().WithMessage("El número de Orden del Día es obligatorio.")
                .Length(6, 10).WithMessage("El número de Orden del Día debe tener entre 6 y 10 caracteres.");

            RuleFor(x => x.FechaInicio)
                .LessThan(x => x.FechaFin)
                .WithMessage("La fecha de inicio debe ser anterior a la fecha de fin.");

            RuleFor(x => x.FechaFin)
                .GreaterThan(x => x.FechaInicio)
                .WithMessage("La fecha de fin debe ser posterior a la fecha de inicio.");
        }
    }
}

