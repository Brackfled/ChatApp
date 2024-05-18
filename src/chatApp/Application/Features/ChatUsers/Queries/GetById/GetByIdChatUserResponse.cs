using NArchitecture.Core.Application.Responses;

namespace Application.Features.ChatUsers.Queries.GetById;

public class GetByIdChatUserResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ChatId { get; set; }
}