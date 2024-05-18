using FluentValidation;

namespace Application.Features.ChatUsers.Commands.Update;

public class UpdateChatUserCommandValidator : AbstractValidator<UpdateChatUserCommand>
{
    public UpdateChatUserCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ChatId).NotEmpty();
        RuleFor(c => c.User).NotEmpty();
        RuleFor(c => c.Chat).NotEmpty();
    }
}