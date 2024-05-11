using NArchitecture.Core.Application.Responses;

namespace Application.Features.Chats.Commands.Delete;

public class DeletedChatResponse : IResponse
{
    public Guid Id { get; set; }
}