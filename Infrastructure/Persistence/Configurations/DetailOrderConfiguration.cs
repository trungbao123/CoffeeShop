using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class DetailOrderConfiguration : IEntityTypeConfiguration<DetailOrder>
    {
        public void Configure(EntityTypeBuilder<DetailOrder> builder)
        {
            builder.HasKey(m => m.DetailOrderId);

            builder.Property(m => m.OrderId);

            builder.Property(m => m.MenuId);

            builder.Property(m => m.MenuName);

            builder.Property(m => m.Quantity);

            builder.Property(m => m.Price);

            builder.Property(m => m.Total);
            //.IsRequired();
        }
    }
}