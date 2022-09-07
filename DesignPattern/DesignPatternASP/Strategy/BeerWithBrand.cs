using DesignPattern.Models.Models;
using DesignPattern.Repository;
using DesignPatternASP.Models;

namespace DesignPatternASP.Strategy
{
    public class BeerWithBrand : IBeerStrategy
    {
        public async Task Add(BeerViewModel beerViewModel, IUnitOfWork unitOfWork)
        {
            var newBeer = new Beer
            {
                Name = beerViewModel.Name,
                Style = beerViewModel.Style,
                BrandId = Guid.Parse(beerViewModel.BrandId)
            };

            await unitOfWork.Beers.Add(newBeer);

            await unitOfWork.Save();
        }
    }
}
