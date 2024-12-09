using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JFS.Domain;
using JFS.Infrastructure.DbContexts;
using JFS.Shared.DTOs;
using JFS.Shared.Requests;
using Microsoft.EntityFrameworkCore;

namespace JFS.Infrastructure.Repositories
{
    public class ReadRepository<T, K> : IReadRepository<T, K>
        where T : class
    {
        private readonly SqlServerDbContext _dbContext;

        public ReadRepository(SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  async Task<IEnumerable<T>> GetAllAsync()
        {
            return await  _dbContext.Set<T>().ToListAsync();
        }

        public Task<T> GetByIdAsync(K id)
        {
            throw new NotImplementedException();
        }
    }
}
