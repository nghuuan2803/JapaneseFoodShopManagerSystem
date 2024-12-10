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
    public class StoreConfig : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.Property(p => p.Id).HasMaxLength(15).HasColumnType("varchar");

            builder.HasOne(p=>p.Manager).WithOne().HasForeignKey<Store>(p=>p.ManagerId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
