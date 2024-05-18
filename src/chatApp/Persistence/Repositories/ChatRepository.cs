using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ChatRepository : EfRepositoryBase<Chat, Guid, BaseDbContext>, IChatRepository
{
    public ChatRepository(BaseDbContext context) : base(context)
    {
    }
}