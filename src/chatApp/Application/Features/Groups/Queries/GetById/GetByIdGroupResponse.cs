using NArchitecture.Core.Application.Responses;

namespace Application.Features.Groups.Queries.GetById;

public class GetByIdGroupResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ChatId { get; set; }
    public string GroupName { get; set; }
}