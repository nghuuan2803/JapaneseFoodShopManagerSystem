using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Shared.DTOs
{
    public class ProductDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string? Images { get; set; }
        public bool Discontinued { get; set; }
        public bool IsHot { get; set; }
        public bool IsNew { get; set; }
        public string? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

    }
}
