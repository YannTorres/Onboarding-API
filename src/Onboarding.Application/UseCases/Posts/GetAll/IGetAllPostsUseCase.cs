using Onboarding.Communication.Response;

namespace Onboarding.Application.UseCases.Posts.GetAll;
public interface IGetAllPostsUseCase
{
    Task<ResponsePostsJson> Execute();
}
