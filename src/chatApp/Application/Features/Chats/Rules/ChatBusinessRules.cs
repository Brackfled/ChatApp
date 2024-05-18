using Application.Features.Chats.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Chats.Rules;

public class ChatBusinessRules : BaseBusinessRules
{
    private readonly IChatRepository _chatRepository;
    private readonly ILocalizationService _localizationService;

    public ChatBusinessRules(IChatRepository chatRepository, ILocalizationService localizationService)
    {
        _chatRepository = chatRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ChatsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ChatShouldExistWhenSelected(Chat? chat)
    {
        if (chat == null)
            await throwBusinessException(ChatsBusinessMessages.ChatNotExists);
    }

    public async Task ChatIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Chat? chat = await _chatRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ChatShouldExistWhenSelected(chat);
    }

}