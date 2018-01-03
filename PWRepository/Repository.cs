using PWEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWRepository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected DataAccessContext context = new DataAccessContext();
       // DbSet<TEntity> dbSet;

        /*public Repository()
        {
            this.dbSet = context.Set<TEntity>();
        }*/
        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public int Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return context.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            return context.SaveChanges();
        }
    }
}
