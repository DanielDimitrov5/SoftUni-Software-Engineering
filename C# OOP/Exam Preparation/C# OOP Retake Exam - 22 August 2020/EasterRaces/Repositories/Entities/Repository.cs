using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        public ICollection<T> Models { get; }

        public Repository()
        {
            Models = new List<T>();
        }

        public void Add(T model)
        {
            Models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return (IReadOnlyCollection<T>)Models;
        }

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            return Models.Remove(model);
        }
    }
}