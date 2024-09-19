using Onboarding.Domain.Repositories.Post;

namespace Onboarding.Infrastructure.DataAcess.Repositories;
internal class PostRepository : IWriteOnlyPostRepository
{
    private readonly OnboardingDbContext _dbcontext;
    public PostRepository(OnboardingDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }


}
