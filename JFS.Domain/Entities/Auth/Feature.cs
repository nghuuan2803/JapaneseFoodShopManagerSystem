using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class Feature
    {
        [Key]
        public string Id { get; set; }

        [MaxLength(30)]
        public required string Name { get; set; } = string.Empty;

        public virtual ICollection<Permission>? Permissions { get; set; }
    }
}
