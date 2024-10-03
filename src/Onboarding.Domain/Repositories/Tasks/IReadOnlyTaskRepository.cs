namespace Onboarding.Domain.Repositories.Tasks;
public interface IReadOnlyTaskRepository
{
    Task<List<Entities.Task>> GetAll();
    Task<Entities.Task?> GetById(long id);
}
