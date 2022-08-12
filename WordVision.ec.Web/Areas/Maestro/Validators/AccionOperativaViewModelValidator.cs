using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Validators
{
    public class AccionOperativaViewModelValidator : AbstractValidator<AccionOperativaViewModel>
    {
        public AccionOperativaViewModelValidator()
        {
            RuleFor(p => p.Codigo)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull().WithMessage("{PropertyName} es obligatorio.");

            RuleFor(p => p.Descripcion)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull().WithMessage("{PropertyName} es obligatorio.");
        }
    }
}
