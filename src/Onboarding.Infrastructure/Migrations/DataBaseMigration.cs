using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Onboarding.Infrastructure.DataAcess;

namespace Onboarding.Infrastructure.Migrations;
public static class DataBaseMigration
{
    public static async Task MigrateDataBase(IServiceProvider serviceProvider)
    {
        var dbcontext = serviceProvider.GetRequiredService<OnboardingDbContext>();
        var dbcontext2 = serviceProvider.GetRequiredService<PortalAuthDbContext>();

        await dbcontext.Database.MigrateAsync();
        await dbcontext2.Database.MigrateAsync();
    }
}
