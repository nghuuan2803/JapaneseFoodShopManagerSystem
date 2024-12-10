using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain
{
    /// <summary>
    /// Has common properties of entities
    /// </summary>
    /// <typeparam name="K">Type of primary key</typeparam>
    public abstract class BaseEntity<K>
    {
        [Key]
        public K Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

        [MaxLength(30)]
        public string? CreatedBy { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        [MaxLength(30)]
        public string? UpdatedBy { get; set; }

        public abstract void NewKey();
        public void UpdateTime()
        {
            UpdatedAt = DateTimeOffset.Now;
        }
    }
}
