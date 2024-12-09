using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class Combo : BaseEntity<Guid>
    {
        public required string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public override void NewKey()
        {
            Id = Guid.NewGuid();
        }
    }
}
