using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileOperatorSoft.DB
{
    abstract class DaoSceleton<T> : IDao<T> where T : IEntity
    {
        private IStorage storage;
        public DaoSceleton(IStorage storage)
        {
            this.storage = storage;
        }
        public int Create(T entity)
        {
            return this.storage.PutEntity(entity);
        }

        public bool Delete(int id)
        {
            return storage.DeleteEntity(id, typeof(T));
        }

        public T Read(int id)
        {
            return (T)storage.GetEntity(id, typeof(T));
        }

        public List<T> ReadAll()
        {
            return storage.GetAll(typeof(T)).Select(entity => (T)entity).ToList<T>();
        }

        public bool Update(int id, T entity)
        {
            return this.storage.UpdateEntity(id, entity);
        }
    }
}
