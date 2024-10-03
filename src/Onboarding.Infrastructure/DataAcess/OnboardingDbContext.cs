using Microsoft.EntityFrameworkCore;

namespace Onboarding.Infrastructure.DataAcess;
internal class OnboardingDbContext : DbContext
{
    public OnboardingDbContext(DbContextOptions<OnboardingDbContext> options) : base(options) { }

    public DbSet<Domain.Entities.Task> Tasks { get; set; }
    public DbSet<Domain.Entities.Feedback> Feedbacks { get; set; }
    public DbSet<Domain.Entities.Post> Posts { get; set; }
    public DbSet<Domain.Entities.Meet> Meets { get; set; }
}
