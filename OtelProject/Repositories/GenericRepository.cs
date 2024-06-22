using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OtelProject.Entity;

namespace OtelProject.Repositories
{
    public class GenericRepository<T> where T : class   //Repository Design Pattern
    {
        DbOtelEntities dbOtelEntities = new DbOtelEntities();

        public List<T> GetAll()
        {
            return dbOtelEntities.Set<T>().ToList();
        }
        public void Insert(T t)
        {
            dbOtelEntities.Set<T>().Add(t);
            dbOtelEntities.SaveChanges();
        }
        public void Delete(T t)
        {
            dbOtelEntities.Set<T>().Remove(t);
            dbOtelEntities.SaveChanges();
        }
        public T GetById(int id)
        {
            return dbOtelEntities.Set<T>().Find(id);
        }
        public void Update(T t)
        {
            dbOtelEntities.SaveChanges();
        }
        public List<T> LinqList(Expression<Func<T, bool>> filter)
        {
            return dbOtelEntities.Set<T>().Where(filter).ToList();
        }
    }
}
