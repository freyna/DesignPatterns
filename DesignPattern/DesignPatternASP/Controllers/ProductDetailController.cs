using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tools.Earn;

namespace DesignPatternASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private LocalEarnFactory localEarnFactory;
        private ForeignEarnFactory foreignEarnFactory;
        public ProductDetailController(LocalEarnFactory localEarnFactory,
            ForeignEarnFactory foreignEarnFactory)
        {
            this.localEarnFactory = localEarnFactory;
            this.foreignEarnFactory = foreignEarnFactory;
        }
        public IActionResult Index(decimal total)
        {
            var localEarn = localEarnFactory.GetEarn();
            var foreignEarn = foreignEarnFactory.GetEarn();

            var totalLocal = total + localEarn.Earn(total);
            var totalForeign = total + foreignEarn.Earn(total);

            var totalPrint = $"Total local: {totalLocal}\n Total Foreign: {totalForeign}";

            return Ok(totalPrint);
        }
    }
}
