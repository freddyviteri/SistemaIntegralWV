using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Validators
{
    public class ProgramaAreaViewModelValidator : AbstractValidator<ProgramaAreaViewModel>
    {
        public ProgramaAreaViewModelValidator()
        {
            RuleFor(p => p.Codigo)
           .NotEmpty().WithMessage("{PropertyName} no espacio.")
           .NotNull().WithMessage("{PropertyName} no null.");

            RuleFor(p => p.Descripcion)
            .NotEmpty().WithMessage("{PropertyName} vvvvves obligatoriovvvvvv.")
            .NotNull();
        }
        //public int Id { get; set; }

        //public string Codigo { get; set; }

        //public string Descripcion { get; set; }

        //public int IdProyectoTecnico { get; set; }
        //public ProyectoTecnicoViewModelValidator ProyectoTecnico { get; set; }

        //public int IdEstado { get; set; }
        //public DetalleCatalogoViewModel Estado { get; set; }

        //public SelectList ProyectoTecnicoList { get; set; }
        //public SelectList EstadoList { get; set; }

    }
}
