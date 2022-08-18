using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Validators
{
    public class ModeloProyectoViewModelValidator : AbstractValidator<ModeloProyectoViewModel>
    {
        public ModeloProyectoViewModelValidator()
        {
            RuleFor(p => p.Codigo)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull().WithMessage("{PropertyName} no puede estar vacío.");

            RuleFor(p => p.Descripcion)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull().WithMessage("{PropertyName} no puede estar vacío.");

            RuleFor(p => p.IdEtapaModeloProyecto)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();
        }

    }
}
