using Core.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.CommonRepository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected OnlineDatabaseContext Context;

        protected Repository(OnlineDatabaseContext context)
        {
            Context = context;
        }
        public void Delete(T obj)
        {
            Context.Set<T>().Remove(obj);
            Context.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return Context.Set<T>().SingleOrDefault(where);
        }

        public void Insert(T obj)
        {
            Context.Set<T>().Add(obj);
            SaveChanges();
        }

        public List<T> List()
        {
            return Context.Set<T>().ToList();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return Context.Set<T>().Where(where).ToList();
        }


        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Update(T obj)
        {
            Context.SaveChanges();
        }
    }
}
