using Application.Services.Chats;
using Application.Services.ChatUsers;
using Application.Services.UsersService;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using NArchitecture.Core.Persistence.Paging;
using NArchitecture.Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SignalR.Hubs;
public class ChatHub: Hub
{
    private readonly IUserService _userService;
    private readonly IChatService _chatService;
    private readonly IChatUserService _chatUserService;

    public ChatHub(IUserService userService, IChatService chatService, IChatUserService chatUserService)
    {
        _userService = userService;
        _chatService = chatService;
        _chatUserService = chatUserService;
    }

    public async Task GetListActiveUsersAsync()
    {
        IPaginate<User>? users = await _userService.GetListAsync(
                predicate: u => u.ConnectionId != null,
                index:0,
                size:100,
                cancellationToken:CancellationToken.None
            );

        if(users.Items is not null)
            await Clients.Caller.SendAsync("getListActiveUsers", users.Items);

    }

    public async Task CreateChat(IList<User> users)
    {
        Chat chat = new()
        {
            Id = Guid.NewGuid(),
            Name = await createChatNameAsync(users),
            Description = "Açıklama giriniz Adaş's",
            Messages = new List<Domain.Dtos.Message> { }
        };
        Chat addedChat = await _chatService.AddAsync(chat);


        foreach (User user in users)
        {
            ChatUser chatUser = new()
            {
                Id = Guid.NewGuid(),
                ChatId = addedChat.Id,
                UserId = user.Id,
            };
            await _chatUserService.AddAsync(chatUser);

        }      
    }

    public async Task SendMessage(Guid chatId, Message message)
    {
        IList<ChatUserWithConnectionIdDto> chatUsers = await _chatUserService.GetListByChatIdAsync(chatId);

        IList<string> connectionIds = new List<string>();
        foreach (ChatUserWithConnectionIdDto chatUser in chatUsers) 
        {
            if(chatUser.UserId != message.UserId)
            {
                connectionIds.Add(chatUser.UserConnectionId);
            }
        }

        await Clients.Clients((IReadOnlyList<string>)connectionIds).SendAsync("receivedMessage", message);

        Chat? chat = await _chatService.GetAsync(c => c.Id.Equals(chatId));

        chat.Messages.Add(message);
        await _chatService.UpdateAsync(chat);

    }

    public async Task ConnectConfigureConnectionId(Guid userId)
    {

        await _userService.UpdateConnectionIdAsync(userId, Context.ConnectionId);
    }

    public async Task DisconnectConfigureConnectionId(Guid userId)
    {
        await _userService.UpdateConnectionIdAsync(userId);
    }

    private async Task<string> createChatNameAsync(IList<User> users)
    {
        string name = "";
        foreach (User user in users)
        {
            name = name + " " + user.FirstName;
        }

        string finalName = name + " Sohbeti";
        return finalName;
    }
}
