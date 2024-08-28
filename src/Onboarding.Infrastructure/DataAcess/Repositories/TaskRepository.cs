using Microsoft.EntityFrameworkCore;
using Onboarding.Domain.Repositories.Tasks;

namespace Onboarding.Infrastructure.DataAcess.Repositories;
internal class TaskRepository : IWriteOnlyTaskRepository, IReadOnlyTaskRepository
{
    private readonly OnboardingDbContext _dbcontext;
    public TaskRepository(OnboardingDbContext dbContext)
    {
        _dbcontext = dbContext;
    }

    public async Task<List<Domain.Entities.Task>> GetAll()
    {
        return await _dbcontext.Tasks.AsNoTracking().ToListAsync();
    }

    public async Task<Domain.Entities.Task?> GetById(long id)
    {
        return await _dbcontext.Tasks.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Register(Domain.Entities.Task task)
    {
        await _dbcontext.Tasks.AddAsync(task);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _dbcontext.Tasks.FirstOrDefaultAsync(x => x.Id == id);

        if (result == null)
        {
            return false;
        }

        _dbcontext.Tasks.Remove(result);

        return true;
    }
}
