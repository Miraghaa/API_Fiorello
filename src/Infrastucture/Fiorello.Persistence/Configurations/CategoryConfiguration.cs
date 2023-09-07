using Fiorello.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiorello.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.Property(c=>c.Name).IsRequired().HasMaxLength(50);
		builder.Property(c=>c.Description).HasMaxLength(250);
	}
}
