using Onboarding.Communication.Response.Tasks;

namespace Onboarding.Application.UseCases.Tasks.GetById;
public interface IGetByIdTaskUseCase
{
    Task<ResponseShortTaskJson> Execute(long id);
}
