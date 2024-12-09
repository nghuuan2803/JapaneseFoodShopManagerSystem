using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class FavoriteProduct
    {
        public required string ProductId { get; set; }
        public required string CustomerId { get; set; }

        public Product? Product { get; set; }
        public Customer? Customer { get; set; }
    }
}
