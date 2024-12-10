using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Domain;

namespace JFS.Domain.Entities
{
    public class Category : BaseEntity<string>
    {
        [MaxLength(30)]
        public required string Name { get; set; } = string.Empty;
        public string? Photo { get; set; }

        public string? ParentId { get; set; }
        public Category? Parent { get; set; }

        public virtual ICollection<Category>? SubCategories { get; set; }

        public override void NewKey()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
