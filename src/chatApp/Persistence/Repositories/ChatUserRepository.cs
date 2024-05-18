using Application.Services.Repositories;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ChatUserRepository : EfRepositoryBase<ChatUser, Guid, BaseDbContext>, IChatUserRepository
{
    public ChatUserRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<IList<ChatUserWithConnectionIdDto>> GetListByChatIdAsync(Guid chatId)
    {
        IList<ChatUserWithConnectionIdDto> query = await Query()
            .AsNoTracking()
            .Where(cu => cu.ChatId.Equals(chatId))
            .Select(cu => new ChatUserWithConnectionIdDto
            {
                Id = cu.ChatId,
                UserId = cu.UserId,
                UserConnectionId = cu.User.ConnectionId,
                ChatId = cu.ChatId
            })
            .ToListAsync();

        return query;
    }
}