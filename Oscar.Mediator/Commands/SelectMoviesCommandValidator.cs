using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oscar.Mediator.Commands
{
    public class SelectMoviesCommandValidator : AbstractValidator<SelectMoviesCommand>
    {
        public SelectMoviesCommandValidator()
        {
            //Todo Tratar erros
            //RuleFor(x => x.Id).NotNull();
            //RuleFor(x => x.Id).GreaterThan(4).WithMessage("xo corona");
        }
    }
}
