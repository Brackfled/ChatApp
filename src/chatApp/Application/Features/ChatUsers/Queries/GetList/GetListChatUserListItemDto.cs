using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ChatUsers.Queries.GetList;

public class GetListChatUserListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ChatId { get; set; }
}