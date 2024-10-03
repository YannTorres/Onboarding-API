using Onboarding.Communication.Response.Meets;

namespace Onboarding.Application.UseCases.Meets.GetAll;
public interface IGetAllMeetsUseCase
{
    Task<ResponseMeetsJson> Execute();
}
