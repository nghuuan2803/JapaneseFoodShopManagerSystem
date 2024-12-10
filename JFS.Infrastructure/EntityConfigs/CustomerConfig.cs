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
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(p => p.Id).HasMaxLength(32).HasColumnType("varchar");
            builder.HasOne(p=>p.User)
                .WithOne()
                .HasForeignKey<Customer>(p=>p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
