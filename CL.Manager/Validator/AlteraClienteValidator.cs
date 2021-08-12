using CL.Core.Shared.ModelViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Manager.Validator
{
    public class AlteraClienteValidator : AbstractValidator<AlteraCliente>
    {
        public AlteraClienteValidator()
        {
            RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0); // Validação para o Id (que é o diferencial)
            Include(new NovoClienteValidator()); // Chama o construtor para reutilizar as validações de NovoClienteValidator
        }
    }
}
