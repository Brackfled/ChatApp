using Application.Features.ChatUsers.Commands.Create;
using Application.Features.ChatUsers.Commands.Delete;
using Application.Features.ChatUsers.Commands.Update;
using Application.Features.ChatUsers.Queries.GetById;
using Application.Features.ChatUsers.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.ChatUsers.Queries.GetListByUserId;
using Domain.Dtos;
using Application.Services.ChatUsers;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatUsersController : BaseController
{
    private readonly IChatUserService _chatUserService;

    public ChatUsersController(IChatUserService chatUserService)
    {
        _chatUserService = chatUserService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateChatUserCommand createChatUserCommand)
    {
        CreatedChatUserResponse response = await Mediator.Send(createChatUserCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateChatUserCommand updateChatUserCommand)
    {
        UpdatedChatUserResponse response = await Mediator.Send(updateChatUserCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedChatUserResponse response = await Mediator.Send(new DeleteChatUserCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdChatUserResponse response = await Mediator.Send(new GetByIdChatUserQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListChatUserQuery getListChatUserQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListChatUserListItemDto> response = await Mediator.Send(getListChatUserQuery);
        return Ok(response);
    }

    [HttpGet("GetListByUserId")]
    public async Task<IActionResult> GetListByUserId()
    {
        GetListByUserIdChatUserQuery query = new() { UserId = getUserIdFromRequest() };
        GetListResponse<GetListByUserIdChatUserListItemDto> response = await Mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("GetListByChatId/{chatId}")]
    public async Task<IActionResult> GetListByChatId([FromRoute] Guid chatId)
    {
        IList<ChatUserWithConnectionIdDto> response = await _chatUserService.GetListByChatIdAsync(chatId);
        return Ok(response);
    }
}