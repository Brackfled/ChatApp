using Application.Features.Chats.Commands.Create;
using Application.Features.Chats.Commands.Delete;
using Application.Features.Chats.Commands.Update;
using Application.Features.Chats.Queries.GetById;
using Application.Features.Chats.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateChatCommand createChatCommand)
    {
        CreatedChatResponse response = await Mediator.Send(createChatCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateChatCommand updateChatCommand)
    {
        UpdatedChatResponse response = await Mediator.Send(updateChatCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedChatResponse response = await Mediator.Send(new DeleteChatCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdChatResponse response = await Mediator.Send(new GetByIdChatQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListChatQuery getListChatQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListChatListItemDto> response = await Mediator.Send(getListChatQuery);
        return Ok(response);
    }
}