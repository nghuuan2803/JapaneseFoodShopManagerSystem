using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class VoucherItem
    {
        [Key]
        public Guid Id { get; set; }
        public Guid VoucherId { get; set; }

        public string? CustomerId { get; set; }
        public bool Applied { get; set; }

        public Voucher? Voucher { get; set; }
        public Customer? Customer { get; set; }

        public void NewId()
        {
            Id = Guid.NewGuid();
        }

    }

}
