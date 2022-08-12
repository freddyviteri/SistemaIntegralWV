using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Validators
{
    public class IndicadorMLViewModelValidator : AbstractValidator<IndicadorMLViewModel>
    {
        public IndicadorMLViewModelValidator()
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

            RuleFor(p => p.CWB)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();
        }
    }
}
