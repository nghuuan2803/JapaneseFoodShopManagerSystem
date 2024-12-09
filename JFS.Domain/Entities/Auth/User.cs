using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class User : BaseEntity<Guid>
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public int LoginFailedAttempt { get; set; }
        public DateTimeOffset? LockedEnd { get; set; }
        public bool ConfirmAccount { get; set; }

        public string RoleId { get; set; }

        public override void NewKey()
        {
            Id = Guid.NewGuid();
        }
    }
}
