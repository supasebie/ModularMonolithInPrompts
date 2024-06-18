using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InPrompts.Users.Data;

internal class UserPromptConfiguration : IEntityTypeConfiguration<UserPrompt>
{
  public void Configure(EntityTypeBuilder<UserPrompt> builder)
  {
    builder.ToTable("UserPrompts");
    builder.Property(item => item.Id).ValueGeneratedOnAdd();
  }

}