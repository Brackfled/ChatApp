using Application.Features.ChatUsers.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Domain.Dtos;

namespace Application.Services.ChatUsers;

public class ChatUserManager : IChatUserService
{
    private readonly IChatUserRepository _chatUserRepository;
    private readonly ChatUserBusinessRules _chatUserBusinessRules;

    public ChatUserManager(IChatUserRepository chatUserRepository, ChatUserBusinessRules chatUserBusinessRules)
    {
        _chatUserRepository = chatUserRepository;
        _chatUserBusinessRules = chatUserBusinessRules;
    }

    public async Task<ChatUser?> GetAsync(
        Expression<Func<ChatUser, bool>> predicate,
        Func<IQueryable<ChatUser>, IIncludableQueryable<ChatUser, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ChatUser? chatUser = await _chatUserRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return chatUser;
    }

    public async Task<IPaginate<ChatUser>?> GetListAsync(
        Expression<Func<ChatUser, bool>>? predicate = null,
        Func<IQueryable<ChatUser>, IOrderedQueryable<ChatUser>>? orderBy = null,
        Func<IQueryable<ChatUser>, IIncludableQueryable<ChatUser, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ChatUser> chatUserList = await _chatUserRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return chatUserList;
    }

    public async Task<ChatUser> AddAsync(ChatUser chatUser)
    {
        ChatUser addedChatUser = await _chatUserRepository.AddAsync(chatUser);

        return addedChatUser;
    }

    public async Task<ChatUser> UpdateAsync(ChatUser chatUser)
    {
        ChatUser updatedChatUser = await _chatUserRepository.UpdateAsync(chatUser);

        return updatedChatUser;
    }

    public async Task<ChatUser> DeleteAsync(ChatUser chatUser, bool permanent = false)
    {
        ChatUser deletedChatUser = await _chatUserRepository.DeleteAsync(chatUser);

        return deletedChatUser;
    }

    public async Task<IList<ChatUserWithConnectionIdDto>> GetListByChatIdAsync(Guid chatId)
    {
        IList<ChatUserWithConnectionIdDto> dtoList = await _chatUserRepository.GetListByChatIdAsync(chatId);

        return dtoList;
    }
}
