using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Shared.DTOs
{
    public record SortParams(string param1, string? param2 = null, string? param3 = null);
}
