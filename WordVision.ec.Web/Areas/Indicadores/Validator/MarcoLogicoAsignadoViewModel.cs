using FluentValidation;
using WordVision.ec.Web.Areas.Indicadores.Models;

namespace WordVision.ec.Web.Areas.Indicadores.Validator
{
    public class ProgramaTecnicoPorProgramaAreaViewModelValidator : AbstractValidator<MarcoLogicoAsignadoViewModel>
    {
        public ProgramaTecnicoPorProgramaAreaViewModelValidator()
        {
           // RuleFor(p => p.IdProgramaArea)
           // .NotEmpty().WithMessage("Seleccione un programa de área")
           // .NotNull();

           // RuleFor(p => p.IdProyectoTecnico)
           //.Must((ptxpa, e) =>
           //{
           //    if (ptxpa.IdProgramaArea > 0)
           //    {
           //        return true;
           //    }
           //    return ptxpa.IdProyectoTecnico > 0 ;
           //})
           //.WithMessage("Employee code is required");
        }
    }
}
