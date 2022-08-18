using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Validators
{
    public class EtapaModeloProyectoViewModelValidator : AbstractValidator<EtapaModeloProyectoViewModel>
    {
        public EtapaModeloProyectoViewModelValidator()
        {
            RuleFor(p => p.Etapa)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull();

            RuleFor(p => p.IdAccionOperativa)
             .NotEmpty().WithMessage("Acción Operativa es obligatorio.")
             .NotNull();
        }
    }
}
