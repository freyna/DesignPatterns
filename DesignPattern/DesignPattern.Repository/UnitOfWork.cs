using DesignPattern.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<Beer> beers;
        private IRepository<Brand> brands;
        private DesignPatternContext context;
        public IRepository<Beer> Beers
        {
            get
            {
                return beers == null ? beers = new Repository<Beer>(context) : beers;
            }
        }

        public IRepository<Brand> Brands
        {
            get
            {
                return brands == null ? brands = new Repository<Brand>(context) : brands;
            }
        }

        public UnitOfWork(DesignPatternContext context)
        {
            this.context = context;
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
