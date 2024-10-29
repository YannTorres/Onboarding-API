using ClosedXML.Excel;
using Onboarding.Domain.Repositories.Feedback;

namespace Onboarding.Application.UseCases.Tasks.Reports;

public class GenerateReportFeedbacks : IGenerateReportFeedbacks
{
    private readonly IReadOnlyFeedbackRepository _repository;
    public GenerateReportFeedbacks(IReadOnlyFeedbackRepository repository)
    {
        _repository = repository;
    }
    public async Task<byte[]> Execute(DateTime month)
    {
        var feedbacks = await _repository.FilterByMonth(month);

        if (feedbacks.Count == 0)
        {
            return [];
        }

        using var workbook = new XLWorkbook();

        workbook.Author = "Workday";
        workbook.Style.Font.FontSize = 12;

        var worksheet = workbook.Worksheets.Add(month.ToString("Y"));

        InsertHeader(worksheet);

        var raw = 2;
        foreach (var feedback in feedbacks)
        {
            worksheet.Cell($"A{raw}").Value = feedback.Title;
            worksheet.Cell($"B{raw}").Value = feedback.Description;
            worksheet.Cell($"C{raw}").Value = feedback.CreatedAt;

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
        worksheet.Cell("C1").Value = "Data de Criação";

        worksheet.Cells("A1:E1").Style.Font.Bold = true;
        worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.FromHtml("#20B2AA");

        worksheet.Cells("A1:C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
        worksheet.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

    }
}
