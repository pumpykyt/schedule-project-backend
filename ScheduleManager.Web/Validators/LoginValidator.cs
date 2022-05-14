using FastEndpoints;
using FluentValidation;
using ScheduleManager.Contracts.Requests;

namespace ScheduleManager.Web.Validators;

public class LoginValidator : Validator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(t => t.Email)
            .NotNull().WithMessage("Null")
            .NotEmpty().WithMessage("Empty")
            .EmailAddress().WithMessage("Incorrect email");
        RuleFor(t => t.Password)
            .NotNull().WithMessage("Null")
            .NotEmpty().WithMessage("Empty");
    }
}