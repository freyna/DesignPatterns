using DesignPattern.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Repository
{
    public interface IUnitOfWork
    {
        public IRepository<Beer> Beers { get; }
        public IRepository<Brand> Brands { get; }

        Task Save();
    }
}
