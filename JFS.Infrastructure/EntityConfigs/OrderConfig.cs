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
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //builder.HasOne(p=>p.Customer).WithMany().HasForeignKey(p=>p.CustomerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p=>p.Handler).WithMany().HasForeignKey(p=>p.HandlerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p=>p.Voucher).WithOne().HasForeignKey<Order>(p=>p.VoucherId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
