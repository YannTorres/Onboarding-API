using Onboarding.Communication.Response.Meets;

namespace Onboarding.Application.UseCases.Meets.GetById;
public interface IGetByIdMeetUseCase
{
    Task<ResponseMeetJson> Execute(long id);
}
