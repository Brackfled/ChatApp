using NArchitecture.Core.Application.Responses;

namespace Application.Features.Chats.Commands.Update;

public class UpdatedChatResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}