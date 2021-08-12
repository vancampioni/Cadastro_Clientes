﻿using CL.Core.Shared.ModelViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Manager.Validator
{
    public class NovoTelefoneValidator : AbstractValidator<NovoTelefone>
    {
        public NovoTelefoneValidator()
        {
            RuleFor(p=>p.Numero
            ).Matches("[2-9][0-9]{10}").WithMessage("O telefone tem que ter o formato [2-9]");
        }
        
    }
}
