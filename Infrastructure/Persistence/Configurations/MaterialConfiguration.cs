using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.Property(m => m.MaterialName)
                .HasMaxLength(60)
                .HasAnnotation("MinLength", 3)
                .IsRequired();

            builder.Property(m => m.Quantity)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(m => m.Unit)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(m => m.Status)
                .HasMaxLength(60)
                .HasAnnotation("MinLength", 3);
            //.IsRequired();
            builder.Property(m => m.ReceiptDate);
        }
    }
}