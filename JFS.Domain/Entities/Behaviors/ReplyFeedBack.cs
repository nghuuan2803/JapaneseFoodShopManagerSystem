using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class ReplyFeedBack : BaseEntity<Guid>
    {
        public required string ReplierId { get; set; }
        public Guid FeedBackId { get; set; }

        public required string Content { get; set; }
        public bool IsHide { get; set; }

        public FeedBack? FeedBack { get; set; }
        public Employee? Replier { get; set; }

        public override void NewKey()
        {
            Id = Guid.NewGuid();
        }
    }
}
