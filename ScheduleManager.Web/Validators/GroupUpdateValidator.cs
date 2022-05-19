using FastEndpoints;
using FluentValidation;
using ScheduleManager.Contracts.Requests;

namespace ScheduleManager.Web.Validators;

public class GroupUpdateValidator : Validator<GroupUpdateRequest>
{
    public GroupUpdateValidator()
    {
        RuleFor(t => t.Name)
            .NotNull().WithMessage("Name is null")
            .NotEmpty().WithMessage("Name is empty");
    }
} 