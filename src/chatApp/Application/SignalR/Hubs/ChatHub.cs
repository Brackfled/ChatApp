using Application.Services.UsersService;
using Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SignalR.Hubs;
public class ChatHub: Hub
{
    private readonly IUserService _userService;

    public ChatHub(IUserService userService)
    {
        _userService = userService;
    }

    public async Task GetListActiveUsersAsync()
    {
        List<User> users = (List<User>)await _userService.GetListAsync(
                predicate: u => u.ConnectionId != null,
                index:0,
                size:100,
                enableTracking:false,
                withDeleted:false
            );

        await Clients.Caller.SendAsync("getListActiveUsers", users);
    }

    public async Task ConnectConfigureConnectionId(Guid userId)
    {

        await _userService.UpdateConnectionIdAsync(userId, Context.ConnectionId);
    }

    public async Task DisconnectConfigureConnectionId(Guid userId)
    {
        await _userService.UpdateConnectionIdAsync(userId);
    }
}
