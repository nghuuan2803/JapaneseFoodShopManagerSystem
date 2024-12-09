using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Shared.DTOs;

namespace JFS.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Entity's type</typeparam>
    /// <typeparam name="K">Key's type</typeparam>
    public interface IWriteRepository<T, K>
        where T : class
    {
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entity);

        void Update(T entity);
        void UpdateRange(IEnumerable<T> entity);

        bool Delete(T entity);
        bool DeleteById(K id);
        bool DeleteRange(IEnumerable<T> entity);
    }
}
