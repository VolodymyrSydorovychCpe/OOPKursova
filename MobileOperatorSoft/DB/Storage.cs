using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobileOperatorSoft;

namespace MobileOperatorSoft.DB
{
    class Storage : IStorage
    {
        private Dictionary<Type, Dictionary<int, IEntity>> storage;

        public Storage()
        {
            storage = new Dictionary<Type, Dictionary<int, IEntity>>();
            storage.Add(typeof(Number), new Dictionary<int, IEntity>());
            storage.Add(typeof(Client), new Dictionary<int, IEntity>());
            storage.Add(typeof(Tarif), new Dictionary<int, IEntity>());
        }

        public List<IEntity> GetAll(Type type)
        {
            return storage[type].Values.ToList<IEntity>();            
        }

        public IEntity GetEntity(int id, Type type)
        {
            if (!storage.ContainsKey(type))
            {
                return null;
            }
            if (!storage[type].ContainsKey(id))
            {
                return null;
            }

            return storage[type][id];
        }

        public int PutEntity(IEntity entity)
        {
            if (!storage.ContainsKey(entity.GetType()))
            {
                return -1;
            }

            storage[entity.GetType()][entity.GetId()] = entity;
            return entity.GetId();
        }

        public bool DeleteEntity(int id, Type type)
        {
            if (!storage.ContainsKey(type))
            {
                return false;
            }
            if (!storage[type].ContainsKey(id))
            {
                return false;
            }
            return storage[type].Remove(id);
        }
        
        public bool UpdateEntity(int id, IEntity entity)
        {
            if (!storage.ContainsKey(entity.GetType()))
            {
                return false;
            }
            if (!storage[entity.GetType()].ContainsKey(id))
            {
                return false;
            }
            storage[entity.GetType()][entity.GetId()] = entity;
            return true;
        }

    }
}
