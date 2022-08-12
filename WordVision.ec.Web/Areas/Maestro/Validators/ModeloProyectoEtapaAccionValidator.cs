using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Validators
{
    public class ModeloProyectoEtapaAccionValidator : AbstractValidator<ModeloProyectoEtapaAccionViewModel>
    {
        public ModeloProyectoEtapaAccionValidator()
        {
            RuleFor(p => p.codigosao)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull().WithMessage("{PropertyName} no puede estar vacío.");

            //RuleFor(p => p.Descripcion)
            //.NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            //.NotNull().WithMessage("{PropertyName} no puede estar vacío.");


        }
    }
}
