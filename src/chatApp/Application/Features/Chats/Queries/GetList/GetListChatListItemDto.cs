using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Chats.Queries.GetList;

public class GetListChatListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}