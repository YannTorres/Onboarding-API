
using ClosedXML.Excel;
using Onboarding.Domain.ReportExtensions;
using Onboarding.Domain.Repositories.Tasks;
using System.Drawing;

namespace Onboarding.Application.UseCases.Tasks.Reports;
public class GenerateReportTask : IGenerateReportTasks
{
    private readonly IReadOnlyTaskRepository _repository;
    public GenerateReportTask(IReadOnlyTaskRepository repository)
    {
        _repository = repository;
    }
    public async Task<byte[]> Execute(DateTime month)
    {
        var tasks = await _repository.FilterByMonth(month);

        if (tasks.Count == 0)
        {
            return [];
        }

        using var workbook = new XLWorkbook();

        workbook.Author = "Workday";
        workbook.Style.Font.FontSize = 12;

        var worksheet = workbook.Worksheets.Add(month.ToString("Y"));

        InsertHeader(worksheet);

        var raw = 2;
        foreach (var task in tasks)
        {
            worksheet.Cell($"A{raw}").Value = task.Name;
            worksheet.Cell($"B{raw}").Value = task.Description;
            worksheet.Cell($"C{raw}").Value = task.Status.StatusToString();
            worksheet.Cell($"D{raw}").Value = task.Priority.PriorityToString();
            worksheet.Cell($"E{raw}").Value = task.CreatedAt;

            raw += 1;
        }

        worksheet.Columns().AdjustToContents();

        var file = new MemoryStream();

        workbook.SaveAs(file);

        return file.ToArray();
    }

    private void InsertHeader(IXLWorksheet worksheet)
    {
        worksheet.Cell("A1").Value = "Título";
        worksheet.Cell("B1").Value = "Descrição";
        worksheet.Cell("C1").Value = "Status";
        worksheet.Cell("D1").Value = "Prioridade";
        worksheet.Cell("E1").Value = "Data de Criação";

        worksheet.Cells("A1:E1").Style.Font.Bold = true;
        worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.FromHtml("#20B2AA");

        worksheet.Cells("A1:C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
        worksheet.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

    }
}
