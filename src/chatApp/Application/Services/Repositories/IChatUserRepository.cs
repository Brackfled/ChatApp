using Domain.Dtos;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IChatUserRepository : IAsyncRepository<ChatUser, Guid>, IRepository<ChatUser, Guid>
{

    Task<IList<ChatUserWithConnectionIdDto>> GetListByChatIdAsync(Guid chatId);

}