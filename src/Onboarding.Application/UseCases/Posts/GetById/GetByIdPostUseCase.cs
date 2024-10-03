using Onboarding.Communication.Response.Posts;

namespace Onboarding.Application.UseCases.Posts.GetById;
public class GetByIdPostUseCase : IGetByIdPostUseCase
{
    public GetByIdPostUseCase()
    {
        
    }
    public Task<ResponsePostJson> Execute(long id)
    {
        throw new NotImplementedException();
    }
}
