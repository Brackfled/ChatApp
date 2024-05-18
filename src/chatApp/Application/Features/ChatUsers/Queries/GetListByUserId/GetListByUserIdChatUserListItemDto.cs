using Domain.Dtos;
using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ChatUsers.Queries.GetListByUserId;
public class GetListByUserIdChatUserListItemDto: IDto
{

    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public string UserEmail {  get; set; }
    public string UserConnectionId { get; set; }
    public Guid ChatId { get; set; }
    public string ChatName { get; set; }
    public string ChatDescription { get; set; }
    public List<Message> ChatMessages { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

    public GetListByUserIdChatUserListItemDto()
    {
        UserFirstName = string.Empty;
        UserLastName = string.Empty;
        UserEmail = string.Empty;
        UserConnectionId = string.Empty;
        ChatName = string.Empty;
        ChatDescription = string.Empty;
        ChatMessages = new List<Message>();
    }

    public GetListByUserIdChatUserListItemDto(Guid ıd, Guid userId, string userFirstName, string userLastName, string userEmail, string userConnectionId, Guid chatId, string chatName, string chatDescription, List<Message> chatMessages, DateTime createdDate, DateTime updatedDate, DateTime deletedDate)
    {
        Id = ıd;
        UserId = userId;
        UserFirstName = userFirstName;
        UserLastName = userLastName;
        UserEmail = userEmail;
        UserConnectionId = userConnectionId;
        ChatId = chatId;
        ChatName = chatName;
        ChatDescription = chatDescription;
        ChatMessages = chatMessages;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
        DeletedDate = deletedDate;
    }
}
