using Onboarding.Communication.Requests;
using Onboarding.Communication.Response.Feedback;

namespace Onboarding.Application.UseCases.Feedback.Register;
public interface IRegisterFeedbackUseCase
{
    Task<ResponseRegisteredFeedbackJson> Execute(RequestFeedbackJson request);
}
