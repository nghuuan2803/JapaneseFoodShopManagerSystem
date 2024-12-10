using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class Order : BaseEntity<Guid>
    {
        public string? CustomerId { get; set; }
        public string? HandlerId { get; set; }

        public long OrderCode { get; set; }
        public double Amount { get; set; }
        public double Final { get; set; }

        [MaxLength(15)]
        public string Status { get; set; } = OrderStatus.Creating;

        [MaxLength(15)]
        public string PayMethod { get; set; } = PaymentMethod.Cash;

        public Guid? VoucherId { get; set; }

        public VoucherItem? Voucher { get; set; }
        public Customer? Customer { get; set; }
        public Employee? Handler { get; set; }

        public virtual ICollection<OrderProduct>? Products { get; set; }
        public virtual ICollection<OrderCombo>? Combos { get; set; }


        public override void NewKey()
        {
            Id = Guid.NewGuid();
        }
        public void SetCode()
        {
            OrderCode = DateTime.UtcNow.Ticks;
        }
    }
    public static class OrderStatus
    {
        public const string Creating = "Creating";
        public const string Pending = "Pending";
        public const string Approved = "Approved";
        public const string Shipping = "Shipping";
        public const string Completed = "Completed";
        public const string Canceled = "Canceled";
        public const string Refused = "Refused";
    }

    public static class PaymentMethod
    {
        public const string Cash = "Cash";
        public const string COD = "COD";
        public const string CreditCard = "CreditCard";
        public const string Momo = "Momo";
        public const string VnPay = "VnPay";
    }
}
