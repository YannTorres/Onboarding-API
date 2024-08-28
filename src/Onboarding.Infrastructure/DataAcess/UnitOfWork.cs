using Onboarding.Domain.Repositories;

namespace Onboarding.Infrastructure.DataAcess;
internal class UnitOfWork : IUnitOfWork
{
    private readonly OnboardingDbContext _dbContext;
    public UnitOfWork(OnboardingDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }
}
