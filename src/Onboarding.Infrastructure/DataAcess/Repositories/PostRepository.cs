using Microsoft.EntityFrameworkCore;
using Onboarding.Domain.Entities;
using Onboarding.Domain.Repositories.Post;

namespace Onboarding.Infrastructure.DataAcess.Repositories;
internal class PostRepository : IWriteOnlyPostRepository, IReadOnlyPostRepository
{
    private readonly OnboardingDbContext _dbcontext;
    public PostRepository(OnboardingDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async System.Threading.Tasks.Task Add(Post entity)
    {
        await _dbcontext.Posts.AddAsync(entity);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _dbcontext.Posts.FirstOrDefaultAsync(p => p.Id == id);

        if (result == null)
            return false;

        _dbcontext.Posts.Remove(result);

        return true;
    }

    public async Task<List<Post>> GetAll()
    {
        return await _dbcontext.Posts.AsNoTracking().ToListAsync();
    }

    public Task<Post?> GetById(long id)
    {
        throw new NotImplementedException();
    }
}
