using DesignPattern.Repository;
using DesignPatternASP.Models;

namespace DesignPatternASP.Strategy
{
    public interface IBeerStrategy
    {
        Task Add(BeerViewModel beerViewModel, IUnitOfWork unitOfWork);
    }
}
