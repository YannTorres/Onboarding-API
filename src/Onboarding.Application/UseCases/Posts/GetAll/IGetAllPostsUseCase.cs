using Onboarding.Communication.Response.Posts;

namespace Onboarding.Application.UseCases.Posts.GetAll;
public interface IGetAllPostsUseCase
{
    Task<ResponsePostsJson> Execute();
}
