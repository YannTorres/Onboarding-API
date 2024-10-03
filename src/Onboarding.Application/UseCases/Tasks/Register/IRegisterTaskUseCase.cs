using Onboarding.Communication.Requests;
using Onboarding.Communication.Response.Tasks;

namespace Onboarding.Application.UseCases.Tasks.Register;
public interface IRegisterTaskUseCase
{
    Task<ResponseRegisteredTaskJson> Execute(RequestTaskJson request);
}
