using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Group: Entity<Guid>
{
    public Guid ChatId { get; set; }
    public string GroupName { get; set; }

    public virtual Chat Chat { get; set; } = default!;

    public Group()
    {
        GroupName = string.Empty;
    }

    public Group(Guid chatId, string groupName)
    {
        ChatId = chatId;
        GroupName = groupName;
    }
}
