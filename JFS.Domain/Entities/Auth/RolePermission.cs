using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class RolePermission
    {
        public string RoleId { get; set; }
        public string PermissionId { get; set; }
        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}
