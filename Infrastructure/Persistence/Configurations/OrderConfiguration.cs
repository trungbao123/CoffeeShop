using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(m => m.OrderId);

            builder.Property(m => m.UserNv);

            builder.Property(m => m.NgayLap);

            builder.Property(m => m.TongTien);
            //.IsRequired();
        }
    }
}