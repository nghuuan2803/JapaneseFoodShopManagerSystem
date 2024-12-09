using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class Reply : BaseEntity<Guid>
    {
        public string Content { get; set; }
        public Guid FeedBackId { get; set; }
        public FeedBack FeedBack { get; set; }
        public bool IsHide { get; set; }

        public override void NewKey()
        {
            Id = Guid.NewGuid();
        }
    }
}
