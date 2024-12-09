using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class ProductPromotion : BaseEntity<Guid>
    {
        public required string ProductId { get; set; }
        public required Guid PromotionId { get; set; }

        public required string Type { get; set; }
        public double Value { get; set; }
        public int RequiredQuantity { get; set; }
        public string? GiftId { get; set; }

        public Product? Product { get; set; }
        public Promotion? Promotion { get; set; }
        public Product? Gift { get; set; }

        public override void NewKey()
        {
            Id = Guid.NewGuid();
        }
    }
}
