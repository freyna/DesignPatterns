using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tools;

namespace DesignPatternASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("GetProviders/{id}")]
        public async Task<IActionResult> GetProviders([FromQuery] int id) 
        {
            await Log.GetInstance("log.txt").Save("Entrando a GetProviders");

            return Ok();
        }

        [HttpGet("GetUsers/{url}")]
        public async Task<IActionResult> GetUsers([FromQuery] string url)
        {
            await Log.GetInstance("log.txt").Save("Entrando a GetUsers");

            return Ok();
        }

    }
}
