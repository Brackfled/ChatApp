using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos;
public class ChatUserWithConnectionIdDto 
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string UserConnectionId { get; set; }
    public Guid ChatId { get; set; }

    public ChatUserWithConnectionIdDto()
    {
        UserConnectionId = string.Empty;
    }

    public ChatUserWithConnectionIdDto(Guid ıd, Guid userId, string userConnectionId, Guid chatId)
    {
        Id = ıd;
        UserId = userId;
        UserConnectionId = userConnectionId;
        ChatId = chatId;
    }
}
