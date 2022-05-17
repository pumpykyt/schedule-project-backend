using FastEndpoints;
using FluentValidation;
using ScheduleManager.Contracts.Requests;

namespace ScheduleManager.Web.Validators;

public class ScheduleEventUpdateValidator : Validator<ScheduleEventUpdateRequest>
{
    public ScheduleEventUpdateValidator()
    {
        RuleFor(t => t.Id)
            .NotNull().WithMessage("Id is null")
            .NotEmpty().WithMessage("Id is empty");

        RuleFor(t => t.Start)
            .NotNull().WithMessage("Start date is null")
            .NotEmpty().WithMessage("Start date is empty")
            .GreaterThanOrEqualTo(DateTime.Now);

        RuleFor(t => t.End)
            .NotNull().WithMessage("End date in null")
            .NotEmpty().WithMessage("End date is empty")
            .GreaterThanOrEqualTo(DateTime.Now);

        RuleFor(t => t.Type)
            .NotNull().WithMessage("Type is null")
            .NotEmpty().WithMessage("Type is empty");
    }
}