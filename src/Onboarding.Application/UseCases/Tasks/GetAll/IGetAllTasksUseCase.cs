using Onboarding.Communication.Response;

namespace Onboarding.Application.UseCases.Tasks.GetAll;
public interface IGetAllTasksUseCase
{
    Task<ResponseTasksJson> Execute();
}
