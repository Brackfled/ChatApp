using FluentValidation;

namespace Application.Features.ChatUsers.Commands.Delete;

public class DeleteChatUserCommandValidator : AbstractValidator<DeleteChatUserCommand>
{
    public DeleteChatUserCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}