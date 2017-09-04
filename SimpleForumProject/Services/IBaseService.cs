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
        DbSet<T> Entities { get; }

        T Create(T entity);

        T Update(T entity);

        void Delete(T entity);

        T GetById(int id);

        IQueryable<T> GetAll();
    }
}
