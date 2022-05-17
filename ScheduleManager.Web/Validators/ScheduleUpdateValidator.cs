using FastEndpoints;
using FluentValidation;
using ScheduleManager.Contracts.Requests;

namespace ScheduleManager.Web.Validators;

public class ScheduleUpdateValidator : Validator<ScheduleUpdateRequest>
{
    public ScheduleUpdateValidator()
    {
        RuleFor(t => t.Id)
            .NotNull().WithMessage("Id is null")
            .NotEmpty().WithMessage("Id is empty");
        
        RuleFor(t => t.Name)
            .NotNull().WithMessage("Name is null")
            .NotEmpty().WithMessage("Name is empty");
    }
}