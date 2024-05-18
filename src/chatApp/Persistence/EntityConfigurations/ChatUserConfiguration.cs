using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ChatUserConfiguration : IEntityTypeConfiguration<ChatUser>
{
    public void Configure(EntityTypeBuilder<ChatUser> builder)
    {
        builder.ToTable("ChatUsers").HasKey(cu => cu.Id);

        builder.Property(cu => cu.Id).HasColumnName("Id").IsRequired();
        builder.Property(cu => cu.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(cu => cu.ChatId).HasColumnName("ChatId").IsRequired();
        builder.Property(cu => cu.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cu => cu.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cu => cu.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(cu => cu.User);
        builder.HasOne(cu => cu.Chat);

        builder.HasQueryFilter(cu => !cu.DeletedDate.HasValue);
    }
}