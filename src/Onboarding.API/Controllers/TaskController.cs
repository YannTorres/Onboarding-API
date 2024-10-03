using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onboarding.Application.UseCases.Tasks.Delete;
using Onboarding.Application.UseCases.Tasks.GetAll;
using Onboarding.Application.UseCases.Tasks.GetById;
using Onboarding.Application.UseCases.Tasks.Register;
using Onboarding.Communication.Requests;
using Onboarding.Communication.Response;
using Onboarding.Communication.Response.Tasks;

namespace Onboarding.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredTaskJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterTaskUseCase useCase,
        [FromBody] RequestTaskJson request
        )
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseTasksJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll(
        [FromServices] IGetAllTasksUseCase useCase
        )
    {
        var result = await useCase.Execute();

        if (result.Tasks.Count <= 0)
            return NoContent();
        
        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseShortTaskJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetByIdTaskUseCase useCase,
        [FromRoute] long id
        )
    {
        var result = await useCase.Execute(id);

        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(
        [FromRoute] long id,
        [FromServices] IDeleteTaskUseCase useCase
        )
    {
        await useCase.Execute(id);

        return NoContent();
    }
}
