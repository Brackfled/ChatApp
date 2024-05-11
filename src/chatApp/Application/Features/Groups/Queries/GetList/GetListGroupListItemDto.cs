using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Groups.Queries.GetList;

public class GetListGroupListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid ChatId { get; set; }
    public string GroupName { get; set; }
}