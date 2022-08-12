using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Validators
{
    public class ProyectoTecnicoViewModelValidator : AbstractValidator<ProyectoTecnicoViewModel>
    {
        public ProyectoTecnicoViewModelValidator()
        {
            RuleFor(p => p.Codigo)
          .NotEmpty().WithMessage("{PropertyName} no espacio.")
          .NotNull().WithMessage("{PropertyName} no null.");

        }


    }
}
