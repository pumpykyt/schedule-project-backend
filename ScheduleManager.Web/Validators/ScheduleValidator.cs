using FastEndpoints;
using FluentValidation;
using ScheduleManager.Contracts.Requests;

namespace ScheduleManager.Web.Validators;

public class ScheduleValidator : Validator<ScheduleCreateRequest>
{
    public ScheduleValidator()
    {
        RuleFor(t => t.Name)
            .NotNull().WithMessage("Name is null")
            .NotEmpty().WithMessage("Name is empty")
            .Length(1, 250);
    }       
}