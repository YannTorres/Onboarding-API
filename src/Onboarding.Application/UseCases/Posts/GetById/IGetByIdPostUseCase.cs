using Onboarding.Communication.Response;

namespace Onboarding.Application.UseCases.Posts.GetById;
public interface IGetByIdPostUseCase
{
    public Task<ResponsePostJson> Execute(long id);

}
