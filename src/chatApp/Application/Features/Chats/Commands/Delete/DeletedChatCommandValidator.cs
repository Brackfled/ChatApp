using FluentValidation;

namespace Application.Features.Chats.Commands.Delete;

public class DeleteChatCommandValidator : AbstractValidator<DeleteChatCommand>
{
    public DeleteChatCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}