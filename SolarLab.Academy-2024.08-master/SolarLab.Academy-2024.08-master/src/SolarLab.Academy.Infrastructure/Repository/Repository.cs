using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SolarLab.Academy.Infrastructure.Repository
{
    /// <inheritdoc />
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private BoardDbContext _dbContext;
        private DbSet<TEntity> Entity;
        public Repository(BoardDbContext dbContext)
        {
            _dbContext = dbContext;
            Entity = _dbContext.Set<TEntity>();
        }
        /// <inheritdoc />
        public IQueryable<TEntity> GetAll()
        {
            return   Entity;
        }
        /// <inheritdoc />
        public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await Entity.FindAsync(id);
        }

        /// <inheritdoc />
        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await Entity.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            Entity.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DeleteAsync(int id,CancellationToken cancellationToken)
        {
            var entity = await GetByIdAsync(id,cancellationToken );
            if (entity != null)
            {
                Entity.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
        /// <inheritdoc />
        public IQueryable<TEntity> GetAllFiltered(Expression<Func<TEntity, bool>> predicat)
        {
            if (predicat == null)
            {
                throw new ArgumentNullException(nameof(predicat));
            }
            return Entity.Where(predicat);
        }
    }
}
