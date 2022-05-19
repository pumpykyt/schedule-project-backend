using FastEndpoints;
using FluentValidation;
using ScheduleManager.Contracts.Requests;

namespace ScheduleManager.Web.Validators;

public class ActivityUpdateValidator : Validator<ActivityUpdateRequest>
{
    public ActivityUpdateValidator()
    {
        RuleFor(t => t.Name)
            .NotNull().WithMessage("Name is null")
            .NotEmpty().WithMessage("Name is empty");

        RuleFor(t => t.TeacherName)
            .NotNull().WithMessage("Teacher name is null")
            .NotEmpty().WithMessage("Teacher name is empty");

        RuleFor(t => t.TeacherEmail)
            .NotNull().WithMessage("Teacher email is null")
            .NotEmpty().WithMessage("Teacher email is empty");
    }
}