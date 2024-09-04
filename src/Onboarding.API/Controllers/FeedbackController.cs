using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onboarding.Application.UseCases.Feedback.Register;
using Onboarding.Communication.Requests;
using Onboarding.Communication.Response;

namespace Onboarding.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FeedbackController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromBody] RequestFeedbackJson request,
        [FromServices] IRegisterFeedbackUseCase useCase
        )
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }
}
