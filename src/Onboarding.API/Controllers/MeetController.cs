using Microsoft.AspNetCore.Mvc;
using Onboarding.Application.UseCases.Meets.Delete;
using Onboarding.Application.UseCases.Meets.GetAll;
using Onboarding.Application.UseCases.Meets.GetById;
using Onboarding.Application.UseCases.Meets.Register;
using Onboarding.Communication.Requests;
using Onboarding.Communication.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Onboarding.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MeetController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllMettings([FromServices] IGetAllMeetsUseCase useCase)
    {
        var response = await useCase.Execute();

        if (response.Meets.Count != 0)
            return Ok(response);

        return NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromServices] IGetByIdMeetUseCase useCase, long id)
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromBody] RequestMeetJson request, 
        [FromServices] IRegisterMeetUseCase useCase)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(long id, [FromServices] IDeleteMeetUseCase useCase)
    {
        await useCase.Execute(id);

        return NoContent();
    }
}
