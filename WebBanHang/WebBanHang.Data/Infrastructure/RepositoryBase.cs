using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebBanHang.Data.DomainModels;

namespace WebBanHang.Data.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private WebBanHangDbContext context;
        private readonly IDbSet<T> dbSet;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected WebBanHangDbContext Context
        {
            get { return context ?? (context = DatabaseFactory.Init()); }
        }

        public RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbSet = Context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = dbSet.Where<T>(predicate).AsEnumerable();
            foreach (T entity in entities)
            {
                dbSet.Remove(entity);
            }
            context.SaveChanges();
        }

        public virtual T Get(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).FirstOrDefault<T>();
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }
    }
}
