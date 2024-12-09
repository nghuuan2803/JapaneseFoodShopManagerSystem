using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Shared.Requests
{
    public class PaginRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
