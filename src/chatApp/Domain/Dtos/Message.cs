using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos;
public class Message
{
    public Guid UserId { get; set; }
    public string Text { get; set; }
    public long PostDate { get; set; }

    public Message()
    {
        Text = string.Empty;
    }

    public Message(Guid userId, string text, long postDate)
    {
        UserId = userId;
        Text = text;
        PostDate = postDate;
    }
}
