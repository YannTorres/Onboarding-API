using Microsoft.EntityFrameworkCore;
using Onboarding.Domain.Entities;
using Onboarding.Domain.Repositories.Feedback;
using System.Threading.Tasks;

namespace Onboarding.Infrastructure.DataAcess.Repositories;
internal class FeedbackRepository : IWriteOnlyFeedbackRepository, IReadOnlyFeedbackRepository
{
    private readonly OnboardingDbContext _dbcontext;
    public FeedbackRepository(OnboardingDbContext dbContext)
    {
        _dbcontext = dbContext;
    }

    public async Task<List<Feedback>> FilterByMonth(DateTime month)
    {
        return await _dbcontext.Feedbacks.AsNoTracking()
            .Where(x => x.CreatedAt.Month == month.Month)
            .Where(x => x.CreatedAt.Year == month.Year)
            .ToListAsync();
    }

    public async System.Threading.Tasks.Task Register(Feedback feedback)
    {
        await _dbcontext.Feedbacks.AddAsync(feedback);
    }
}
