using Core.Users.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validation
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            RuleFor(u => u.User)
                .NotNull()
                .WithMessage("User can't be NULL.");
            RuleFor(u => u.User.Id)
                .NotNull()
                .Equal(0)
                .WithMessage("Id must be 0");
            RuleFor(u => u.User.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name can't be empty.")
                .Length(1, 30)
                .WithMessage("Name can't be longer than 30 characters.");
            RuleFor(u => u.User.Visits1)
                .GreaterThan(-1)
                .WithMessage("User visits can't be negative.");
            RuleFor(u => u.User.Visits2)
                .GreaterThan(-1)
                .WithMessage("User visits can't be negative.");
        }
    }
}
