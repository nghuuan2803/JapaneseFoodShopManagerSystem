using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Domain;

namespace JFS.Domain.Entities
{
    public class Category : BaseEntity<string>
    {
        public string Name { get; set; }
        public string? ParentId { get; set; }
        public string? Photo { get; set; }
        public Category? Parent { get; set; }

        public override void NewKey()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
