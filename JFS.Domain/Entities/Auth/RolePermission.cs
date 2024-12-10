using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class RolePermission
    {
        public required string RoleId { get; set; }
        public required string PermissionId { get; set; }
        public Role? Role { get; set; }
        public Permission? Permission { get; set; }
    }
}
