using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBaseService<T> where T : IdProvider
    {
        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        T GetById(int id);

        IQueryable<T> GetAll();
    }
}
