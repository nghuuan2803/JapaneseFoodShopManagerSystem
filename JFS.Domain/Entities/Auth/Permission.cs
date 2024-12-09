using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class Permission
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public ActionType ActionType { get; set; }
        public string FeatureId { get; set; } // use to group by
        public Feature? Feature { get; set; }
    }
    public enum ActionType
    {
        Create = 1,
        Edit = 2,
        Delete = 3,
        CanView = 4
    }
}
