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
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p=>p.Id).HasMaxLength(15).HasColumnType("varchar");

            builder.HasOne(p=>p.Category)
                .WithMany()
                .HasForeignKey(p=>p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
