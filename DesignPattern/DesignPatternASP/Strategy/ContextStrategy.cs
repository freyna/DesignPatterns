using DesignPattern.Repository;
using DesignPatternASP.Models;

namespace DesignPatternASP.Strategy
{
    public class ContextStrategy
    {
        private IBeerStrategy strategy;

        public IBeerStrategy Strategy
        {
            set => strategy = value;
        }

        public ContextStrategy(IBeerStrategy strategy)
        {
            this.strategy = strategy;
        }

        public async Task Add(BeerViewModel beerViewModel, IUnitOfWork unitOfWork)
        {
            await strategy.Add(beerViewModel, unitOfWork);
        }
    }
}
