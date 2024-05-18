using FluentValidation;

namespace Application.Features.ChatUsers.Commands.Create;

public class CreateChatUserCommandValidator : AbstractValidator<CreateChatUserCommand>
{
    public CreateChatUserCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ChatId).NotEmpty();
        RuleFor(c => c.User).NotEmpty();
        RuleFor(c => c.Chat).NotEmpty();
    }
}