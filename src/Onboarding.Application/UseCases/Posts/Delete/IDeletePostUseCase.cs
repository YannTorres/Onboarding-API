namespace Onboarding.Application.UseCases.Posts.Delete;
public interface IDeletePostUseCase
{
    Task Execute(long id);
}
