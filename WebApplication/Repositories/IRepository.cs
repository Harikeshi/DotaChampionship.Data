using DotaChampionship.Data;
using System;
using System.Collections.Generic;

namespace WebApplication.Repositories
{
    public interface IRepository<T>  where T : class
    {
        IEnumerable<T> GetAll();       
        T Get(int id);
        void Create(T item);
        void Update(T item);
        T Delete(int id);
        void Save(T item);

    }
}