using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Domain.Dtos;

namespace Application.Services.ChatUsers;

public interface IChatUserService
{
    Task<ChatUser?> GetAsync(
        Expression<Func<ChatUser, bool>> predicate,
        Func<IQueryable<ChatUser>, IIncludableQueryable<ChatUser, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ChatUser>?> GetListAsync(
        Expression<Func<ChatUser, bool>>? predicate = null,
        Func<IQueryable<ChatUser>, IOrderedQueryable<ChatUser>>? orderBy = null,
        Func<IQueryable<ChatUser>, IIncludableQueryable<ChatUser, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ChatUser> AddAsync(ChatUser chatUser);
    Task<ChatUser> UpdateAsync(ChatUser chatUser);
    Task<ChatUser> DeleteAsync(ChatUser chatUser, bool permanent = false);

    Task<IList<ChatUserWithConnectionIdDto>> GetListByChatIdAsync(Guid chatId);
}
