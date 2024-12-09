using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class Employee : BaseEntity<string>
    {
        public required string Name { get; set; } = string.Empty;
        public required string Gender { get; set; } = "Nam";
        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Address { get; set; }
        public string? StoreId { get; set; }
        public Store? Store { get; set; }

        public override void NewKey()
        {
            throw new NotImplementedException();
        }
    }
}
