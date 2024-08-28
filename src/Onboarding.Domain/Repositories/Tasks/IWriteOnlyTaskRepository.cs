using Onboarding.Domain;

namespace Onboarding.Domain.Repositories.Tasks;
public interface IWriteOnlyTaskRepository
{
    Task Register(Entities.Task task);
    /// <summary>
    /// Returns true if Task was deleted and false for not.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> Delete(long id);
}
