﻿namespace Picbook.Repository.EntityFramework.GenericsEFRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Entities;

    public abstract class GenericEfRepository<TEntity> :  IGenericsEfRepository<TEntity> where TEntity : class
    {
        protected PicBookContext Context;
        private bool _disposedValue;

        protected GenericEfRepository(PicBookContext ctx) => Context = ctx ?? new PicBookContext();

        public async Task<IReadOnlyCollection<TEntity>> FindAll(Expression<Func<TEntity, bool>> filterExpression)
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public abstract Task<TEntity> GetById(Guid id);


        public virtual async Task<int> Count(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return await Context.Set<TEntity>().CountAsync(predicate);
        }

        public virtual async Task Create(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Context.Set<TEntity>().Attach(entity);
            Context.Set<TEntity>().Add(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
        }

        public virtual async Task Delete(Guid id)
        {
            var entitiyToDelete =  await GetById(id);
            await Delete(entitiyToDelete);
        }

        public async Task<IReadOnlyCollection<TEntity>> GetByFilter(Expression<Func<TEntity, bool>> filterExpression)
        {
            IQueryable<TEntity> entities = Context.Set<TEntity>();
            if (filterExpression != null)
            {
                entities = entities.Where(filterExpression);
            }

            return await entities.ToListAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
