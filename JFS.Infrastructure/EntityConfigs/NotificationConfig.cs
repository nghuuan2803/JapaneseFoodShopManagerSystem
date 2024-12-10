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
    public class NotificationConfig : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasOne(p=>p.Receiver).WithMany().HasForeignKey(p=>p.ReceiverId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p=>p.Sender).WithMany().HasForeignKey(p=>p.SenderId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
