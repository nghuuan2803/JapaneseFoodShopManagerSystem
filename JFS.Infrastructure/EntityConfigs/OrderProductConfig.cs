using JFS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Infrastructure.EntityConfigs
{
    public class OrderProductConfig : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasKey(p => new {p.OrderId, p.ProductId});

            builder.HasOne(p=>p.Product).WithMany().HasForeignKey(p=>p.ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p=>p.ProductPromotion).WithMany().HasForeignKey(p=>p.ProductPromotionId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
