namespace DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using BLEntity;

    using DAL.Repositories.Interfaces;

    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity> 
        where TEntity : class
        where TContext : DbContext
    {
        private DbSet<TEntity> dbSet;

        public GenericRepository(TContext context)
        {
            Context = context;
            this.dbSet = context.Set<TEntity>();
        }

        protected TContext Context { get; }


        public IEnumerable<TEntity> Get()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public TEntity FindById(int id)
        {
            return dbSet.Find(id);
        }

        public void Create(TEntity item)
        {
            dbSet.Add(item);
            Context.SaveChanges();
        }

        public void Update(TEntity item)
        {
            Context.Entry(item).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Remove(TEntity item)
        {
            dbSet.Remove(item);
            Context.SaveChanges();
        }

        public int CreateOrUpdate(TEntity entity, Func<TEntity, bool> predicate)
        {
            int id;

            var foundedItem = dbSet.FirstOrDefault(predicate);
            if (foundedItem != null)
            {
                id = (foundedItem as IIdentifier).Id;
            }
            else
            {
                Create(entity);
                id = (entity as IIdentifier).Id;
            }

            return id;
        }
    }
}