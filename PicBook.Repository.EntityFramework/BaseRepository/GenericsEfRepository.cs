using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PicBook.Repository.EntityFramework.BaseRepository
{
    public abstract class GenericsEfRepository<TEntity> : IGenericsEfRepository<TEntity> where TEntity : class
    {
        protected DbContext Database;

        protected GenericsEfRepository(DbContext newDatabase)
        {
            Database = newDatabase ?? throw new ArgumentNullException(nameof(newDatabase));
        }

        public abstract void Delete(int id);
        public abstract TEntity GetById(int id);
        public abstract void Update(TEntity entityToModify);

        public void Delete(TEntity entityToDelete)
        {
            Database.Set<TEntity>().Remove(entityToDelete);
            Database.Entry<TEntity>(entityToDelete).State = EntityState.Deleted;
            try
            {
                Database.SaveChanges();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Database.Set<TEntity>();
        }

        public virtual void Insert(TEntity newEntity)
        {
            Database.Set<TEntity>().Add(newEntity);
            Database.Entry(newEntity).State = EntityState.Added;
            try
            {
                Database.SaveChanges();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
