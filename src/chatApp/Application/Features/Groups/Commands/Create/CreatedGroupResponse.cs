using NArchitecture.Core.Application.Responses;

namespace Application.Features.Groups.Commands.Create;

public class CreatedGroupResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ChatId { get; set; }
    public string GroupName { get; set; }
}