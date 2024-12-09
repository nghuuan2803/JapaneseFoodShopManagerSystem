using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class FeedBack : BaseEntity<Guid>
    {
        public required string Content { get; set; }
        public string UserId { get; set; }
        public int Rate { get; set; } = 5;
        public bool IsHide { get; set; }

        public int LikeCount { get; set; }

        public User? User { get; set; }

        public override void NewKey()
        {
            Id = Guid.NewGuid();
        }
    }
}
