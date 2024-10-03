using Onboarding.Domain.Entities;

namespace Onboarding.Domain.Repositories.Meets;
public interface IReadOnlyMeetRepository
{
    Task<List<Meet>> GetAll();
    Task<Meet?> GetById(long id);
}
