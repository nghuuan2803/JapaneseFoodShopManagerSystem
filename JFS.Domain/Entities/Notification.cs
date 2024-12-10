using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }

        public Guid ReceiverId  { get; set; }
        public User? Receiver { get; set; }

        public Guid? SenderId { get; set; }
        public User? Sender { get; set; }

        public int MyProperty { get; set; }

        public required string Content { get; set; }

        public string? Symbol { get; set; }
        [MaxLength(50)]
        public string? Link { get; set; }

        public bool IsChecked { get; set; }
        public DateTimeOffset SendAt { get; set; }
    }

    public enum NotificationType
    {
        Auth,
        Order,
        Voucher
    }
}
