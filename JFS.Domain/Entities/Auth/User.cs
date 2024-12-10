using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class User : BaseEntity<Guid>
    {
        [MaxLength(30)]
        public required string UserName { get; set; }

        [StringLength(maximumLength:100,MinimumLength = 6)]
        public required string Password { get; set; }

        public int LoginFailedAttempt { get; set; }
        public DateTimeOffset? LockedEnd { get; set; }
        public bool ConfirmAccount { get; set; }

        public string? RoleId { get; set; }
        public Role? Role { get; set; }

        public override void NewKey()
        {
            Id = Guid.NewGuid();
        }
    }
}
