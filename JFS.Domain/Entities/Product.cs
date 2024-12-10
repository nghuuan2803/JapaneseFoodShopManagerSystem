using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Domain;

namespace JFS.Domain.Entities
{
    public class Product : BaseEntity<string>
    {
        [MaxLength(30)]
        public required string Name { get; set; }

        public string? Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int Expire { get; set; } = 7;

        [MaxLength(15)]
        public required string UnitType { get; set; } = "Hộp";
        public string? Photos { get; set; }
        public bool IsHot { get; set; }
        public bool Discontinued { get; set; }
        public bool IsNew { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public string? CategoryId { get; set; }
        public Category? Category { get; set; }

        public int LikeCount { get; set; } = new Random().Next(5000);

        [Range(1, 5)]
        public double Rating { get; set; } = Math.Max(1, (new Random().NextDouble() * 5));

        public virtual ICollection<FeedBack>? FeedBacks { get; set; }

        public override void NewKey()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
