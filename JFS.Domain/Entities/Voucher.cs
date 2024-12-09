using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class Voucher
    {
        [Key]
        public Guid Id { get; set; }

        public DiscountType DiscountType { get; set; } = DiscountType.Percent;
        public string? CustomerId { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public bool Applied { get; set; }

        public Customer Customer { get; set; }

        public void NewId()
        {
            Id = Guid.NewGuid();
        }
        public void SetEndDate(int days)
        {
            if(days < 1)
                days = 1;
            EndDate = StartDate.AddDays(days);
        }
    }
    public enum DiscountType
    {
        Percent,
        point
    }
}
