using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JFS.Shared.DTOs;
using JFS.Shared.Requests;

namespace JFS.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    /// <typeparam name="K">Key's type</typeparam>
    public interface IReadRepository<T, K>
        where T : class
    {
        Task<T> GetByIdAsync(K id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
