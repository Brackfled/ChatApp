using Domain.Dtos;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Chat:Entity<Guid>
{
    public List<User> Users { get; set; }
    public List<Message> Messages { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = default!;

    public Chat()
    {
        Users = new List<User>();
        Messages = new List<Message>();
        Name = string.Empty;
        Description = string.Empty;
    }

    public Chat(List<User> users, List<Message> messages, string name, string description)
    {
        Users = users;
        Messages = messages;
        Name = name;
        Description = description;
    }
}
