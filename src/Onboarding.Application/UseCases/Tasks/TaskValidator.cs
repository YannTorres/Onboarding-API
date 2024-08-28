using FluentValidation;
using Onboarding.Communication.Requests;

namespace Onboarding.Application.UseCases.Tasks;
public class TaskValidator : AbstractValidator<RequestTaskJson>
{
    public TaskValidator()
    {
        RuleFor(task => task.Name).NotEmpty().WithMessage("The Title is Required.");
        RuleFor(task => task.Status).IsInEnum().WithMessage("Invalid status.");
        RuleFor(expense => expense.Priority).IsInEnum().WithMessage("Invalid priority.");
    }
}
