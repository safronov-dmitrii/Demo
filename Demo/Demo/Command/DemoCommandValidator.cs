using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;

public class DemoCommandValidator : AbstractValidator<DemoCommand>
{
    public DemoCommandValidator() {
        RuleFor(x => x.Text)
            .NotNull();
    }
}
