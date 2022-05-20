using FastEndpoints;
using FluentValidation;
using ScheduleManager.Contracts.Requests;

namespace ScheduleManager.Web.Validators;

public class ScheduleEventCreateValidator : Validator<ScheduleEventCreateRequest>
{
    public ScheduleEventCreateValidator()
    {
        RuleFor(t => t.Start)
            .NotNull().WithMessage("Start date is null")
            .NotEmpty().WithMessage("Start date is empty")
            .GreaterThanOrEqualTo(DateTime.Now);

        RuleFor(t => t.End)
            .NotNull().WithMessage("End date is null")
            .NotEmpty().WithMessage("End date is empty")
            .GreaterThanOrEqualTo(DateTime.Now)
            .GreaterThan(t => t.Start);

        RuleFor(t => t.Type)
            .NotNull().WithMessage("Type is null")
            .NotEmpty().WithMessage("Type is empty");
    }
}