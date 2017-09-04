using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class BaseService<T> : IBaseService<T> where T : IdProvider
    {
        public virtual IForumContext Context { get; set; }

        public BaseService(IForumContext context)
        {
            Context = context;
        }

        public virtual DbSet<T> Entities
        {
            get { return Context.Set<T>(); }
        }

        public virtual T Create(T entity)
        {
            Entities.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public virtual T Update(T entity)
        {
            var storedEntity = Entities.FirstOrDefault(x => x.Id == entity.Id);

            if (storedEntity == null)
            {
                entity.Id = 0;
                return Create(entity);
            }
            else
            {
                Context.SetModified(storedEntity, entity);
                Context.SaveChanges();
            }
            return entity;
        }

        public virtual void Delete(T entity)
        {
            Entities.Remove(entity);
            Context.SaveChanges();
        }

        public virtual T GetById(int id)
        {
            return Entities.FirstOrDefault(x => x.Id == id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return Entities;
        }
    }
}
