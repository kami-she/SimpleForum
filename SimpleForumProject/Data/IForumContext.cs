using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IForumContext
    {
        DbSet<User> Users { get; }

        DbSet<Topic> Topics { get; }

        DbSet<TopicMessage> TopicMessages { get; }

        DbSet<T> Set<T>() where T : class;

        int SaveChanges();

        DbEntityEntry Entry(object entity);

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
