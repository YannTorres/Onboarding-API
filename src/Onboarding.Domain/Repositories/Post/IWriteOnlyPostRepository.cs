namespace Onboarding.Domain.Repositories.Post;
public interface IWriteOnlyPostRepository
{
    Task Add(Entities.Post entity);
    Task<bool> Delete(long id);
}
