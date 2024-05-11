using NArchitecture.Core.Application.Responses;

namespace Application.Features.Chats.Queries.GetById;

public class GetByIdChatResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}