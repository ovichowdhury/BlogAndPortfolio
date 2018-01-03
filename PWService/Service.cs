using PWEntity;
using PWRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWService
{
    public class Service<TEntity> : IService<TEntity> where TEntity : Entity
    {
        private IRepository<TEntity> repository = new Repository<TEntity>();

        public List<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public TEntity Get(int id)
        {
            return repository.Get(id);
        }

        public int Insert(TEntity entity)
        {
            return repository.Insert(entity);
        }

        public int Delete(int id)
        {
            TEntity entity = this.Get(id);
            return repository.Delete(entity);
        }
    }
}
