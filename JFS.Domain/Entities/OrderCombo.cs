using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class OrderCombo
    {
        public Guid OrderId { get; set; }
        public Guid ComboId { get; set; }
        public int Quantity { get; set; }

        public Order? Order { get; set; }
        public Combo? Combo { get; set; }
    }
}
