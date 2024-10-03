using Onboarding.Communication.Requests;
using Onboarding.Communication.Response.Meets;

namespace Onboarding.Application.UseCases.Meets.Register;
public interface IRegisterMeetUseCase
{
    Task<ResponseRegisteredMeetJson> Execute(RequestMeetJson request);
}
