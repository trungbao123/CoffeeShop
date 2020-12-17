using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.Property(m => m.Name)
                .HasMaxLength(60)
                .HasAnnotation("MinLength", 3)
                .IsRequired();

            builder.Property(m => m.Genre)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(m => m.Price)
                .HasAnnotation("Range", (1, 100))
                .HasColumnType("decimal(18,2)");

            builder.Property(m => m.Status)
                .HasMaxLength(60)
                .HasAnnotation("MinLength", 3);
            //.IsRequired();
        }
    }
}