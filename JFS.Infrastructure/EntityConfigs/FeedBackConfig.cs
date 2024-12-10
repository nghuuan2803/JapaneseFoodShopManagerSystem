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
    public class FeedBackConfig : IEntityTypeConfiguration<FeedBack>
    {
        public void Configure(EntityTypeBuilder<FeedBack> builder)
        {
            builder.HasOne(p=>p.User)
                .WithMany()
                .HasForeignKey(p=>p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
