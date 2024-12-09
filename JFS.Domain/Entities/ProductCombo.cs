using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class ProductCombo
    {
        public string ProductId { get; set; }
        public Guid ComboId { get; set; }
        public int Quantity { get; set; }

        public Product? Product { get; set; }
        public Combo? Combo { get; set; }

    }
}
