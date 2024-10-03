using Onboarding.Domain.Entities;

namespace Onboarding.Domain.Repositories.Meets;
public interface IWriteOnlyMeetRepository
{
    System.Threading.Tasks.Task Add(Meet meet);

    Task<bool> Delete(long id);
}
