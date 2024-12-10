using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class Voucher : BaseEntity<Guid>
    {
        [MaxLength(100)]
        public required string Name { get; set; } = string.Empty;

        public DiscountType DiscountType { get; set; } = DiscountType.Percent;
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public int ItemCount { get; set; }

        public virtual ICollection<VoucherItem>? Vouchers { get; set; }

        public void SetEndDate(int days)
        {
            if (days < 1)
                days = 1;
            EndDate = StartDate.AddDays(days);
        }
        public override void NewKey()
        {
            Id = Guid.NewGuid();
        }
    }
    public enum DiscountType
    {
        Percent,
        point
    }
}
