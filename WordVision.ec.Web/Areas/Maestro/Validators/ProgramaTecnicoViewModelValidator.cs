using FluentValidation;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Validators
{
    public class ProgramaTecnicoViewModelValidator : AbstractValidator<ProgramaTecnicoViewModel>
    {
        public ProgramaTecnicoViewModelValidator()
        {


            RuleFor(p => p.Codigo)
            .NotEmpty().WithMessage("{PropertyName} no obligatorio.").InjectValidator()
            .NotNull().WithMessage("{PropertyName} no null.").InjectValidator();

            RuleFor(p => p.Nombre)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull().WithMessage("{PropertyName} no null.");

            RuleFor(p => p.Descripcion)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            .NotNull();
        }

        //protected override bool PreValidate(ValidationContext<ProgramaTecnicoViewModel> context, FluentValidation.Results.ValidationResult result)
        //{
        //    if (context.InstanceToValidate == null)
        //    {
        //        result.Errors.Add(new ValidationFailure("ProgramaTecnicoViewModel", "Please ensure a model was supplied"));

        //        return false;
        //    }


        //    return true;
        //}




    }
}
