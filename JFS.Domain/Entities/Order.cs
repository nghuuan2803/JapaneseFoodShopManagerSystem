using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class Order : BaseEntity<int>
    {
        public required string? CustomerId { get; set; }
        public string? Handler { get; set; }
        public required string OrderCode { get; set; }
        public double Amount { get; set; }
        public double Final { get; set; }
        public string Status { get; set; } = OrderStatus.Creating;
        public Guid? VoucherId { get; set; }

        public Voucher? Voucher { get; set; }
        public Customer? Customer { get; set; }


        public override void NewKey()
        {
            OrderCode = Guid.NewGuid().ToString();
        }
        public void SetCode()
        {
            OrderCode = Guid.NewGuid().ToString();
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
