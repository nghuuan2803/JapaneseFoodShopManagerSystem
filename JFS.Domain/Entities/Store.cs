using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class Store : BaseEntity<string>
    {

        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(30)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(30)]
        public string? FbPage { get; set; } = string.Empty;

        [MaxLength(150)]
        public string Address { get; set; } = string.Empty;

        public double Profit { get; set; }
        public string? ManagerId { get; set; } = string.Empty;
        public Employee? Manager { get; set; }

        public override void NewKey()
        {
            throw new NotImplementedException();
        }
    }
}
