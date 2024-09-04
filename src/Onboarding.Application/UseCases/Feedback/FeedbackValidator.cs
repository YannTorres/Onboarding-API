using FluentValidation;
using Onboarding.Communication.Requests;

namespace Onboarding.Application.UseCases.Feedback;
public class FeedbackValidator : AbstractValidator<RequestFeedbackJson>
{
    public FeedbackValidator()
    {
        RuleFor(feedback => feedback.Title).NotEmpty().WithMessage("O Titulo não pode ser Vazio");
        RuleFor(feedback => feedback.Description).NotEmpty().WithMessage("A Descrição é obrigatória");
    }
}
