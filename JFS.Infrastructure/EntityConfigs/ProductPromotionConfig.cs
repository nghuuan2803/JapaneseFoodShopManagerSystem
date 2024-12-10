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
    public class ProductPromotionConfig : IEntityTypeConfiguration<ProductPromotion>
    {
        public void Configure(EntityTypeBuilder<ProductPromotion> builder)
        {
            builder.HasOne(p=>p.Product).WithMany().HasForeignKey(p=>p.ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p=>p.Gift).WithMany().HasForeignKey(p=>p.GiftId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
