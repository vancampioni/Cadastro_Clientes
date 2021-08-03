using CL.Core.Domain;
using CL.Core.Shared.ModelViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Manager.Validator
{
    public class NovoClienteValidator : AbstractValidator<NovoCliente>
    {
        public NovoClienteValidator() //Colocar regras de validação
        {
            RuleFor(x => x.Nome_Cliente).NotNull().NotEmpty().MinimumLength(10).MaximumLength(150);
            RuleFor(x => x.DataNascimento).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-130));
            RuleFor(x => x.Documento).NotNull().NotEmpty().MinimumLength(4).MaximumLength(14);
            RuleFor(x => x.Telefone).NotNull().NotEmpty().Matches("[2-9][0-9]{10}").WithMessage("O telefone tem que ter o formato [2-9]");
            RuleFor(x => x.Sexo).NotNull().NotEmpty().Must(IsMOrF).WithMessage("Esse campo deve ser preenchido com 'M' ou 'F'.");

        }

        private bool IsMOrF(char sexo)
        {
            return sexo == 'M' || sexo == 'F';
        }
    }
}
