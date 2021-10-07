using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LegalAdvice.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LegalAdvice.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly AppDbContext DbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await DbContext.Set<T>().FindAsync(id).ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await DbContext.Set<T>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<T> AddAsync(T entity)
        {
            await DbContext.Set<T>().AddAsync(entity).ConfigureAwait(false);
            await DbContext.SaveChangesAsync().ConfigureAwait(false);

            return entity;
        }

        public Task UpdateAsync(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            return DbContext.SaveChangesAsync();
        }

       
    }
}
