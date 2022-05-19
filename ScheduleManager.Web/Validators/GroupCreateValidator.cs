using FastEndpoints;
using FluentValidation;
using ScheduleManager.Contracts.Requests;

namespace ScheduleManager.Web.Validators;

public class GroupCreateValidator : Validator<GroupCreateRequest>
{
    public GroupCreateValidator()
    {
        RuleFor(t => t.Name)
            .NotNull().WithMessage("Name is null")
            .NotEmpty().WithMessage("Name is empty");
    }
} 