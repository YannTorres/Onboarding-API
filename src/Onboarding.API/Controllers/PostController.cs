using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Onboarding.Application.UseCases.Posts.Delete;
using Onboarding.Application.UseCases.Posts.GetAll;
using Onboarding.Application.UseCases.Posts.GetById;
using Onboarding.Application.UseCases.Posts.Register;
using Onboarding.Communication.Requests;
using Onboarding.Communication.Response;
using Onboarding.Communication.Response.Posts;

namespace Onboarding.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredPostJson),StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromBody] RequestPostJson request,
        [FromServices] IRegisterPostUseCase useCase
        )
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponsePostJson),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetById(
        [FromRoute] long id,
        [FromServices] IGetByIdPostUseCase useCase
    )
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponsePostsJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll(
        [FromServices] IGetAllPostsUseCase useCase
    )
    {
        var response = await useCase.Execute();

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromRoute] long id,
        [FromServices] IDeletePostUseCase useCase
    )
    {
        await useCase.Execute(id);

        return NoContent();
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(
        [FromRoute] long id,
        [FromServices] IDeletePostUseCase useCase,
        [FromBody] RequestPostJson request
    )
    {
        await useCase.Execute(id);

        return NoContent();
    }

}
