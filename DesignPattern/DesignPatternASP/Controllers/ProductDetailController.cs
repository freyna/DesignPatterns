using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tools.Earn;

namespace DesignPatternASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        public IActionResult Index(decimal total)
        {
            LocalEarnFactory localEarnFactory = new LocalEarnFactory(0.20m);
            ForeignEarnFactory foreignEarnFactory = new ForeignEarnFactory(0.30m, 20);

            var localEarn = localEarnFactory.GetEarn();
            var foreignEarn = foreignEarnFactory.GetEarn();

            var totalLocal = total + localEarn.Earn(total);
            var totalForeign = total + foreignEarn.Earn(total);

            var totalPrint = $"Total local: {totalLocal}\n Total Foreign: {totalForeign}";

            return Ok(totalPrint);
        }
    }
}
