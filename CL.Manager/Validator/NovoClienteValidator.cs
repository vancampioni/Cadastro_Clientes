﻿using CL.Core.Domain;
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
            RuleFor(x => x.Telefones).NotNull().NotEmpty();
            RuleFor(x => x.Sexo).NotNull();
            RuleFor(x => x.Endereco).SetValidator(new NovoEnderecoValidator());
        }

    }
}
