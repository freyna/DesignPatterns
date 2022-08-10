using DesignPattern.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Repository
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
        public async Task Add(TEntity data)
        {
            await dbSet.AddAsync(data);
        }

        public async Task Delete(int id)
        {
            var entity = await dbSet.FindAsync(id);

            if (entity == null) return;

            dbSet.Remove(entity);
        }

        public async Task<TEntity> Get(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public void Update(TEntity data)
        {
            dbSet.Attach(data);
            context.Entry(data).State = EntityState.Modified;
        }
    }
}
