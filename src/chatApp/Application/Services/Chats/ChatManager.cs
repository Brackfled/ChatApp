using Application.Features.Chats.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Chats;

public class ChatManager : IChatService
{
    private readonly IChatRepository _chatRepository;
    private readonly ChatBusinessRules _chatBusinessRules;

    public ChatManager(IChatRepository chatRepository, ChatBusinessRules chatBusinessRules)
    {
        _chatRepository = chatRepository;
        _chatBusinessRules = chatBusinessRules;
    }

    public async Task<Chat?> GetAsync(
        Expression<Func<Chat, bool>> predicate,
        Func<IQueryable<Chat>, IIncludableQueryable<Chat, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Chat? chat = await _chatRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return chat;
    }

    public async Task<IPaginate<Chat>?> GetListAsync(
        Expression<Func<Chat, bool>>? predicate = null,
        Func<IQueryable<Chat>, IOrderedQueryable<Chat>>? orderBy = null,
        Func<IQueryable<Chat>, IIncludableQueryable<Chat, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Chat> chatList = await _chatRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return chatList;
    }

    public async Task<Chat> AddAsync(Chat chat)
    {
        Chat addedChat = await _chatRepository.AddAsync(chat);

        return addedChat;
    }

    public async Task<Chat> UpdateAsync(Chat chat)
    {
        Chat updatedChat = await _chatRepository.UpdateAsync(chat);

        return updatedChat;
    }

    public async Task<Chat> DeleteAsync(Chat chat, bool permanent = false)
    {
        Chat deletedChat = await _chatRepository.DeleteAsync(chat);

        return deletedChat;
    }
}
