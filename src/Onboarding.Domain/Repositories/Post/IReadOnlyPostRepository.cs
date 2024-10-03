namespace Onboarding.Domain.Repositories.Post;
public interface IReadOnlyPostRepository
{
    Task<List<Entities.Post>> GetAll();
    Task<Entities.Post?> GetById(long id);
}
