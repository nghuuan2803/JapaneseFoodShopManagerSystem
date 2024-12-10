using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class Customer : BaseEntity<string>
    {
        [MaxLength(30)]
        public required string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;

        [MaxLength(150)]
        public string Address { get; set; } = string.Empty;

        [MaxLength(30)]
        public string? Email { get; set; }

        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        [MaxLength(30)]
        public string Level { get; set; } = "Bronze";

        public int CurrentPoint { get; set; }
        public int CumulativePoint { get; set; }

        public Guid? UserId { get; set; }
        public User? User { get; set; }

        public virtual ICollection<FavoriteProduct>? Favorites { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<VoucherItem>? Vouchers { get; set; }

        public override void NewKey()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
