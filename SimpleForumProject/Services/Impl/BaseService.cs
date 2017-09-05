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
        protected virtual IForumContext Context { get; set; }

        public BaseService(IForumContext context)
        {
            Context = context;
        }

        protected virtual DbSet<T> Entities
        {
            get { return Context.Set<T>(); }
        }

        public virtual void Create(T entity)
        {
            Entities.Add(entity);
            Context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            var storedEntity = Entities.FirstOrDefault(x => x.Id == entity.Id);

            if (storedEntity == null)
            {
                entity.Id = 0;
                Create(entity);
            }
            else
            {
                Context.SetModified(storedEntity, entity);
                Context.SaveChanges();
            }
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
