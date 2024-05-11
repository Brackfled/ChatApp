using Application.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Hubs;
public class ChatHubManager : IChatHubService
{
    private IHubContext<ChatHub> _hubContext;

    public ChatHubManager(IHubContext<ChatHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public Task<List<string>> GetConnectionIds()
    {
        throw new NotImplementedException();
    }
}
