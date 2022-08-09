using DesignPattern.Models.Models;
using DesignPattern.Repository;
using DesignPatternASP.Configuration;
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
        public BeerController(IOptions<MyConfig> config, IRepository<Beer> repository)
        {
            this.config = config;
            this.repository = repository;
        }
        [HttpGet("GetBeers/{id}")]
        public async Task<IActionResult> GetBeers([FromQuery] int id)
        {
            var beer = repository.Get(id);

            if (beer == null) return NotFound();

            var output = $"Id: {beer.BeerId} | Name: {beer.Name} | Style: {beer.Style}";

            return Ok(output);
        }
    }
}
