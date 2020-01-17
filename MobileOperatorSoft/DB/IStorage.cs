using System;
using System.Collections.Generic;
using System.Text;

namespace MobileOperatorSoft.DB
{
    interface IStorage
    {
        List<IEntity> GetAll(Type type);

        IEntity GetEntity(int id, Type type);

        int PutEntity(IEntity entity);

        bool DeleteEntity(int id, Type type);

        bool UpdateEntity(int id, IEntity entity);
    }
}
