using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class Store : BaseEntity<string>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? FbPage { get; set; } = string.Empty;
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
