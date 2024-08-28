namespace Onboarding.Domain.Repositories;
public interface IUnitOfWork
{
    public Task Commit();
}
