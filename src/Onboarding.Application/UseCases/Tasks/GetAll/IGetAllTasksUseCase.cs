using Onboarding.Communication.Response.Tasks;

namespace Onboarding.Application.UseCases.Tasks.GetAll;
public interface IGetAllTasksUseCase
{
    Task<ResponseTasksJson> Execute();
}
