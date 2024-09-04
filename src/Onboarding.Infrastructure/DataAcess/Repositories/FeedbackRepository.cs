using Onboarding.Domain.Entities;
using Onboarding.Domain.Repositories.Feedback;
using System.Threading.Tasks;

namespace Onboarding.Infrastructure.DataAcess.Repositories;
internal class FeedbackRepository : IWriteOnlyFeedbackRepository
{
    private readonly OnboardingDbContext _dbcontext;
    public FeedbackRepository(OnboardingDbContext dbContext)
    {
        _dbcontext = dbContext;
    }

    public async System.Threading.Tasks.Task Register(Feedback feedback)
    {
        await _dbcontext.Feedbacks.AddAsync(feedback);
    }
}
