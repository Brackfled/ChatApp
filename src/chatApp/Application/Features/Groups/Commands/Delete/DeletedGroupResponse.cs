using NArchitecture.Core.Application.Responses;

namespace Application.Features.Groups.Commands.Delete;

public class DeletedGroupResponse : IResponse
{
    public Guid Id { get; set; }
}