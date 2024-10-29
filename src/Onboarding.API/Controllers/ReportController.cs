using Microsoft.AspNetCore.Mvc;
using Onboarding.Application.UseCases.Tasks.Reports;
using System.Net.Mime;

namespace Onboarding.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    [HttpGet("excel/tasks")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetExcelTasks(
        [FromServices] IGenerateReportTasks useCase,
        [FromHeader] DateTime datee) // não pode ser pelo body pois é um endpoint get.
    {
        byte[] file = await useCase.Execute(datee);

        if (file.Length > 0)
            return File(file, MediaTypeNames.Application.Octet, "report.xlsx");
        
        return NoContent(); 
    }

    [HttpGet("excel/feedback")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetExcelFeedback(
    [FromServices] IGenerateReportFeedbacks useCase,
    [FromHeader] DateTime datee) // não pode ser pelo body pois é um endpoint get.
    {
        byte[] file = await useCase.Execute(datee);

        if (file.Length > 0)
            return File(file, MediaTypeNames.Application.Octet, "report.xlsx");

        return NoContent();
    }
}
