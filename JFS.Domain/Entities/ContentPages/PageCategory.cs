using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class PageCategory : BaseEntity<string>
    {
        public string Name { get; set; }
        public string? ParentId { get; set; }
        public string? Slug { get; set; }
        public PageCategory? Parent { get; set; }

        public override void NewKey()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
