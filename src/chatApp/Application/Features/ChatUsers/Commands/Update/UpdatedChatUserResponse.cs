using NArchitecture.Core.Application.Responses;

namespace Application.Features.ChatUsers.Commands.Update;

public class UpdatedChatUserResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ChatId { get; set; }
}