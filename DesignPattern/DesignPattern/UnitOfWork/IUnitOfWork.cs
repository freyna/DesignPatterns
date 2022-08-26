using DesignPattern.Models;
using DesignPattern.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRepository<Beer> Beers { get; }
        public IRepository<Brand> Brands { get; }

        Task Save();
    }
}
