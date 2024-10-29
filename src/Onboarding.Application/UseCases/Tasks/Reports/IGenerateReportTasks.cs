namespace Onboarding.Application.UseCases.Tasks.Reports;
public interface IGenerateReportTasks
{
   Task<byte[]> Execute(DateTime month);
}
