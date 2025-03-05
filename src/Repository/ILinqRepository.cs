﻿using LinqApi.Model;
using System.Linq.Expressions;

namespace LinqApi.Repository
{
    public interface ILinqRepository<TEntity, TId>
     where TEntity : class
    {
        Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(TId id, CancellationToken cancellationToken = default);
        Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<PaginationModel<TEntity>> GetPagedFilteredAsync(
             Expression<Func<TEntity, bool>> predicate,
             int pageNumber,
             int pageSize,
             List<string> includes = null,
             Expression<Func<TEntity, object>> orderBy = null,
             bool descending = false,
             CancellationToken cancellationToken = default);
    }

}
