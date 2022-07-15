using DesignPatternASP.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Tools;

namespace DesignPatternASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IOptions<MyConfig> config;

        //Se inyecta la variable del appsettings desde el program.cs
        public HomeController(IOptions<MyConfig> config)
        {
            this.config = config;
        }

        [HttpGet("GetProviders/{id}")]
        public async Task<IActionResult> GetProviders([FromQuery] int id) 
        {
            await Log.GetInstance(config.Value.PathLog).Save("Entrando a GetProviders");

            return Ok();
        }

        [HttpGet("GetUsers/{url}")]
        public async Task<IActionResult> GetUsers([FromQuery] string url)
        {
            await Log.GetInstance(config.Value.PathLog).Save("Entrando a GetUsers");

            return Ok();
        }

    }
}
