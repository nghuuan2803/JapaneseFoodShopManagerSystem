using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class Promotion : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public string CustomerLevelRequired { get; set; } = string.Empty;
        public string? Banner { get; set; }

        public override void NewKey()
        {
            Id = Guid.NewGuid();
        }
    }
}
