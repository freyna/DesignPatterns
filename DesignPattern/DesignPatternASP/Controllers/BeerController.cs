using DesignPattern.Models.Models;
using DesignPattern.Repository;
using DesignPatternASP.Configuration;
using DesignPatternASP.Models;
using DesignPatternASP.Strategy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DesignPatternASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IOptions<MyConfig> config;
        private readonly IRepository<Beer> repository;

        private readonly IUnitOfWork unitOfWork;
        public BeerController(IOptions<MyConfig> config, IRepository<Beer> repository, IUnitOfWork unitOfWork)
        {
            this.config = config;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBeerById(int id)
        {
            var beer = await repository.Get(id);

            if (beer == null) return NotFound();

            var output = $"Id: {beer.BeerId} | Name: {beer.Name} | Style: {beer.Style}";

            return Ok(output);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBeers()
        {
            var beers = await unitOfWork.Beers.GetAll();

            if (beers == null) return NotFound();

            var listOutputs = new List<string>();

            foreach (var beer in beers)
            {
                listOutputs.Add($"Id: {beer.BeerId} | Name: {beer.Name} | Style: {beer.Style} | Brand: {beer.Brand.Name}") ;
            }

            return Ok(listOutputs);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBeer([FromBody] BeerViewModel beer)
        {
            if(beer == null) return NotFound();

            var context = string.IsNullOrEmpty(beer.BrandId) 
                ? new ContextStrategy(new BeerNewBrand()) 
                : new ContextStrategy(new BeerWithBrand());

            await context.Add(beer, unitOfWork);

            return Ok($"Beer {beer.Name}, style {beer.Style} was added");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBeer([FromBody] Beer beer, int id)
        {
            var foundBeer = await repository.Get(id);

            if (foundBeer == null)
            {
                return NotFound();
            }

            foundBeer.Name = beer.Name;
            foundBeer.Style = beer.Style;
                
            repository.Update(foundBeer);

            await repository.Save();

            return Ok($"Beer with id {beer.BeerId} was updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeer(int id)
        {
            var foundBeer = await repository.Get(id);

            if (foundBeer == null)
            {
                return NotFound();
            }

            await repository.Delete(id);

            await repository.Save();

            return Ok($"Beer with id {foundBeer.BeerId} was deleted");
        }
    }
}
