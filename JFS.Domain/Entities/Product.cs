using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Domain;

namespace JFS.Domain.Entities
{
    public class Product : BaseEntity<string>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int Expire { get; set; } = 7;
        public string? Photos { get; set; }
        public bool IsHot { get; set; }
        public bool Discontinued { get; set; }
        public bool IsNew { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string? CategoryId { get; set; }
        public Category? Category { get; set; }

        public override void NewKey()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
