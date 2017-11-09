namespace Picbook.Repository.EntityFramework.GenericsEFRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IGenericsEfRepository<TEntity> : IDisposable  where TEntity : class
    {
        Task<int> Count(Expression<Func<TEntity, bool>> predicate);
        Task Create(TEntity entity);
        Task Delete(TEntity entity);
        Task Delete(Guid id);
        Task<IReadOnlyCollection<TEntity>> FindAll(Expression<Func<TEntity, bool>> filterExpression);
        Task<IReadOnlyCollection<TEntity>> GetByFilter(Expression<Func<TEntity, bool>> filterExpression);
        Task<TEntity> GetById(Guid id);
        Task Update(TEntity entity);
    }
}