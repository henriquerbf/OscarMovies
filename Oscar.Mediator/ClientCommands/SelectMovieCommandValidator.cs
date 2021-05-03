using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oscar.Mediator.ClientCommands
{
    public class SelectMovieCommandValidator : AbstractValidator<SelectMovieCommand>
    {
        public SelectMovieCommandValidator()
        {
            //Todo Tratar erros
            //RuleFor(x => x.Id).NotNull();
            //RuleFor(x => x.Id).GreaterThan(4).WithMessage("xo corona");
        }
    }
}
