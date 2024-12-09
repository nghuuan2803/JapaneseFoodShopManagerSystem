using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class PageTag
    {
        public string PageId { get; set; }
        public string TagId { get; set; }

        public ContentPage? Page { get; set; }
        public Tag? Tag { get; set; }
    }
}
