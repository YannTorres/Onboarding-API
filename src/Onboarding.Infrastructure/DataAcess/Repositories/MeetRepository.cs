using Microsoft.EntityFrameworkCore;
using Onboarding.Domain.Entities;
using Onboarding.Domain.Repositories.Meets;

namespace Onboarding.Infrastructure.DataAcess.Repositories;
internal class MeetRepository : IWriteOnlyMeetRepository, IReadOnlyMeetRepository
{
    private readonly OnboardingDbContext _dbContext;
    public MeetRepository(OnboardingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async System.Threading.Tasks.Task Add(Meet meet)
    {
        await _dbContext.Meets.AddAsync(meet);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _dbContext.Meets.FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (result == null)
            return false;

        _dbContext.Meets.Remove(result);

        return true;
    }

    public async Task<List<Meet>> GetAll()
    {
        return await _dbContext.Meets.AsNoTracking().ToListAsync();
    }

    public async Task<Meet?> GetById(long id)
    {
        return await _dbContext.Meets.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
    }
}
