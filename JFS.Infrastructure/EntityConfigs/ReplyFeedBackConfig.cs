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
    public class ReplyFeedBackConfig : IEntityTypeConfiguration<ReplyFeedBack>
    {
        public void Configure(EntityTypeBuilder<ReplyFeedBack> builder)
        {
            builder.HasOne(p=>p.Replier).WithMany().HasForeignKey(p=>p.ReplierId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
