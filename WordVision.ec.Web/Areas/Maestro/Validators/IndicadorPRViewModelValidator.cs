using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Validators
{
    public class IndicadorPRViewModelValidator : AbstractValidator<IndicadorPRViewModel>
    {
        public IndicadorPRViewModelValidator()
        {
            RuleFor(p => p.Codigo)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();

            RuleFor(p => p.Descripcion)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();

            RuleFor(p => p.Asunciones)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();

            RuleFor(p => p.MedioVerificacion)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();

            RuleFor(p => p.Poblacion)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull().GreaterThan(0);

            RuleFor(p => p.CWB)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();
        }
    }
}
