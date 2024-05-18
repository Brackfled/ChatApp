using Application.Features.ChatUsers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.ChatUsers.Rules;

public class ChatUserBusinessRules : BaseBusinessRules
{
    private readonly IChatUserRepository _chatUserRepository;
    private readonly ILocalizationService _localizationService;

    public ChatUserBusinessRules(IChatUserRepository chatUserRepository, ILocalizationService localizationService)
    {
        _chatUserRepository = chatUserRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ChatUsersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ChatUserShouldExistWhenSelected(ChatUser? chatUser)
    {
        if (chatUser == null)
            await throwBusinessException(ChatUsersBusinessMessages.ChatUserNotExists);
    }

    public async Task ChatUserIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ChatUser? chatUser = await _chatUserRepository.GetAsync(
            predicate: cu => cu.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ChatUserShouldExistWhenSelected(chatUser);
    }
}