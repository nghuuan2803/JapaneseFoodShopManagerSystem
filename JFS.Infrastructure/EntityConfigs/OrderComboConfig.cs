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
    public class OrderComboConfig : IEntityTypeConfiguration<OrderCombo>
    {
        public void Configure(EntityTypeBuilder<OrderCombo> builder)
        {
            builder.HasKey(p => new { p.OrderId, p.ComboId });

            builder.HasOne(p => p.Combo)
                .WithMany()
                .HasForeignKey(p => p.ComboId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
