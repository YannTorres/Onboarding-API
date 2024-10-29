namespace Onboarding.Domain.Repositories.Tasks;
public interface IReadOnlyTaskRepository
{
    Task<List<Entities.Task>> GetAll();
    Task<Entities.Task?> GetById(long id);
    Task<List<Entities.Task>> FilterByMonth(DateTime month);
}
