using MobileOperatorSoft.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileOperatorSoft.Services
{
    class ServiceSkeleton<T> : IService<T>
    {
        private IDao<T> dao;
        public ServiceSkeleton(IDao<T> dao)
        {
            this.dao = dao;
        }
        public int Create(T entity)
        {
            return this.dao.Create(entity);
        }

        public bool Delete(int id)
        {
            return dao.Delete(id);
        }

        public T Read(int id)
        {
            return dao.Read(id);
        }
        
        public List<T> ReadAll()
        {
            return dao.ReadAll();
        }

        public bool Update(int id, T entity)
        {
            return this.dao.Update(id, entity);
        }
    }
}
