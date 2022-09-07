using DesignPattern.Models.Models;
using DesignPattern.Repository;
using DesignPatternASP.Models;

namespace DesignPatternASP.Strategy
{
    public class BeerNewBrand : IBeerStrategy
    {
        public async Task Add(BeerViewModel beerViewModel, IUnitOfWork unitOfWork)
        {
            var newBrand = new Brand
            {
                BrandId = Guid.NewGuid(),
                Name = beerViewModel.OtherBrand
            };

            var newBeer = new Beer
            {
                Name = beerViewModel.Name,
                Style = beerViewModel.Style,
                BrandId = newBrand.BrandId
            };

            await unitOfWork.Brands.Add(newBrand);
            await unitOfWork.Beers.Add(newBeer);

            await unitOfWork.Save();
        }
    }
}
