namespace Onboarding.Domain.Repositories.Feedback;
public interface IWriteOnlyFeedbackRepository
{
    Task Register(Entities.Feedback feedback);
}
