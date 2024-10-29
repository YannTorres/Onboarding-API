namespace Onboarding.Domain.Repositories.Feedback;
public interface IReadOnlyFeedbackRepository
{
    Task<List<Entities.Feedback>> FilterByMonth(DateTime month);
}
