using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class Promotion : BaseEntity<Guid>
    {
        [MaxLength(100)]
        public required string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }

        [MaxLength(15)]
        public string CustomerLevelRequired { get; set; } = string.Empty;
        public string? Banner { get; set; }

        public virtual ICollection<ProductPromotion>? Products { get; set; }

        public override void NewKey()
        {
            Id = Guid.NewGuid();
        }
    }
}
