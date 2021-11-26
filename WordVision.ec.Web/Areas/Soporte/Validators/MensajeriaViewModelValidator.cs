﻿using FluentValidation;
using WordVision.ec.Web.Areas.Soporte.Models;

namespace WordVision.ec.Web.Areas.Soporte.Validators
{
    public class MensajeriaViewModelValidator : AbstractValidator<MensajeriaViewModel>
    {
        public MensajeriaViewModelValidator()
        {
            RuleFor(p => p.PersonaaContactar)
                .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                .NotNull()
                .MaximumLength(150).WithMessage("{PropertyName} no debe exceder 15 caracteres.");

            RuleFor(p => p.Telefono)
                .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
                .NotNull()
                .MaximumLength(15).WithMessage("{PropertyName} no debe exceder 15 caracteres.");

            RuleFor(p => p.Celular)
               .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
               .NotNull()
               .MaximumLength(10).WithMessage("{PropertyName} no debe exceder 10 caracteres.");

            //RuleFor(p => p.Archivo)
            //   .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
            //   .NotNull();


            RuleFor(p => p.DescripcionTramite)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull().MaximumLength(500).WithMessage("{PropertyName} no debe exceder 500 caracteres.");

            RuleFor(p => p.Direccion)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull().MaximumLength(500).WithMessage("{PropertyName} no debe exceder 500 caracteres.");

            RuleFor(p => p.InformacionAdicional)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .NotNull().MaximumLength(500).WithMessage("{PropertyName} no debe exceder 500 caracteres.");
        }
    }
}
