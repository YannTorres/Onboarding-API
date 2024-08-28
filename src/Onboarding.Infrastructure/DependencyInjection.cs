﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onboarding.Domain.Repositories;
using Onboarding.Domain.Repositories.Tasks;
using Onboarding.Infrastructure.DataAcess;
using Onboarding.Infrastructure.DataAcess.Repositories;

namespace Onboarding.Infrastructure;
public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbcContext(services, configuration);
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IWriteOnlyTaskRepository, TaskRepository>();
        services.AddScoped<IReadOnlyTaskRepository, TaskRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static void AddDbcContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 35));
        services.AddDbContext<OnboardingDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }
}
