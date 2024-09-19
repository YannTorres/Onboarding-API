using Onboarding.Communication.Requests;
using Onboarding.Communication.Response;

namespace Onboarding.Application.UseCases.Posts.Register;
public interface IRegisterPostUseCase
{
    public Task<ResponseRegisteredPostJson> Execute(RequestPostJson request);
}
