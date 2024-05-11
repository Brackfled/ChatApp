using FluentValidation;

namespace Application.Features.Groups.Commands.Update;

public class UpdateGroupCommandValidator : AbstractValidator<UpdateGroupCommand>
{
    public UpdateGroupCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ChatId).NotEmpty();
        RuleFor(c => c.GroupName).NotEmpty();
    }
}