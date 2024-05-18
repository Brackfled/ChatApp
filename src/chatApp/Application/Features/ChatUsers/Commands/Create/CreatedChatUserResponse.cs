using NArchitecture.Core.Application.Responses;

namespace Application.Features.ChatUsers.Commands.Create;

public class CreatedChatUserResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ChatId { get; set; }
}