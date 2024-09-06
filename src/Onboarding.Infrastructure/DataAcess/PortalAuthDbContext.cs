using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Onboarding.Domain.Entities;

namespace Onboarding.Infrastructure.DataAcess
{
    public class PortalAuthDbContext(DbContextOptions<PortalAuthDbContext> options) : IdentityDbContext<PortalUser>(options)
    {
    }
}
