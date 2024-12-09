using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginAsync();
        Task CommitAsync();
        Task RollBackAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
