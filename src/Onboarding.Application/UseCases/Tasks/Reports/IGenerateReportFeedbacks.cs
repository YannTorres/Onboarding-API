namespace Onboarding.Application.UseCases.Tasks.Reports;
public interface IGenerateReportFeedbacks
{
    Task<byte[]> Execute(DateTime month);
}
