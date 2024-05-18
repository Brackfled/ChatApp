using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ChatUser: Entity<Guid>
{
    public Guid UserId { get; set; }
    public Guid ChatId { get; set; }

    public User User { get; set; } = default!;
    public Chat Chat { get; set; } = default!;
}
