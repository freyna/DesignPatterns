using DesignPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.RepositoryPattern
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    { 
        private DesignPatternContext context;
        private DbSet<TEntity> dbSet;
        public Repository(DesignPatternContext context)
        {
            this.context = context;
            //Nos permite asignar cualquier entidad del context.
            this.dbSet = context.Set<TEntity>();
        }
        public void Add(TEntity data)
        {
            dbSet.Add(data);
        }

        public void Delete(int id)
        {
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public TEntity Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(TEntity data)
        {
            dbSet.Attach(data);
            context.Entry(data).State = EntityState.Modified;
        }
    }
}
