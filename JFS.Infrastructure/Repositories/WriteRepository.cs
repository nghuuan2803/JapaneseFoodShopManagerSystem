using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Domain;
using JFS.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace JFS.Infrastructure.Repositories
{
    public class WriteRepository<T, K> : IWriteRepository<T, K>
        where T : class
    {
        protected readonly SqlServerDbContext _dbContext;

        public WriteRepository(SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entity)
        {
            await _dbContext.AddRangeAsync(entity);
        }

        public bool Delete(T entity)
        {
            var trackedEntity = _dbContext.ChangeTracker
            .Entries<T>()
            .FirstOrDefault(e => e.Entity.Equals(entity)); // Tìm đối tượng đã được theo dõi

            if (trackedEntity != null)
            {
                // Sử dụng đối tượng đang được theo dõi
                _dbContext.Remove(trackedEntity.Entity);
            }
            else
            {
                // Đính kèm đối tượng mới nếu chưa được theo dõi
                _dbContext.Attach(entity);
                _dbContext.Remove(entity);
            }

            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteById(K id)
        {
            var entity = _dbContext.Set<T>().Find(id);
            if (entity != null)
            {
                _dbContext.Remove(entity);
                return true;
            }
            else
            { 
                return false; 
            }
        }

        public bool DeleteRange(IEnumerable<T> entity)
        {
            _dbContext.Set<T>().RemoveRange(entity);
            return true;
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<T> entity)
        {
            throw new NotImplementedException();
        }
    }
}
