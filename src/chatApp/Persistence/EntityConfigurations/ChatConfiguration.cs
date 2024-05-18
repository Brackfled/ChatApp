using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Persistence.EntityConfigurations;

public class ChatConfiguration : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder.ToTable("Chats").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name");
        builder.Property(c => c.Description).HasColumnName("Description");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.Property(c => c.Messages).HasColumnName("Messages")
            .HasConversion(
                c => JsonConvert.SerializeObject(c),
                c => JsonConvert.DeserializeObject<List<Message>>(c) ?? new List<Message>()
            );

        builder.HasMany(c => c.ChatUsers);
        builder.HasMany(c => c.Groups);

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}