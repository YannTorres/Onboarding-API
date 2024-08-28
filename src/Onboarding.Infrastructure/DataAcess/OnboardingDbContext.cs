using Microsoft.EntityFrameworkCore;
using Onboarding.Domain.Entities;

namespace Onboarding.Infrastructure.DataAcess;
internal class OnboardingDbContext : DbContext
{
    public OnboardingDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Domain.Entities.Task> Tasks { get; set; }
}
