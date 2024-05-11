using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Chats;

public interface IChatService
{
    Task<Chat?> GetAsync(
        Expression<Func<Chat, bool>> predicate,
        Func<IQueryable<Chat>, IIncludableQueryable<Chat, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Chat>?> GetListAsync(
        Expression<Func<Chat, bool>>? predicate = null,
        Func<IQueryable<Chat>, IOrderedQueryable<Chat>>? orderBy = null,
        Func<IQueryable<Chat>, IIncludableQueryable<Chat, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Chat> AddAsync(Chat chat);
    Task<Chat> UpdateAsync(Chat chat);
    Task<Chat> DeleteAsync(Chat chat, bool permanent = false);
}
