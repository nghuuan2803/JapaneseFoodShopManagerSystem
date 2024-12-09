using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class Role : BaseEntity<string>
    {
        public required string Name { get; set; }

        public virtual ICollection<RolePermission>? Permissions { get; set; }

        public override void NewKey()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
