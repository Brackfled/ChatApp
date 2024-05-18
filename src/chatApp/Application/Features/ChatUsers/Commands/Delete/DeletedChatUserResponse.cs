using NArchitecture.Core.Application.Responses;

namespace Application.Features.ChatUsers.Commands.Delete;

public class DeletedChatUserResponse : IResponse
{
    public Guid Id { get; set; }
}