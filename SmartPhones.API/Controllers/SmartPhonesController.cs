using SmartPhones.Business;
using Microsoft.AspNetCore.Mvc;

namespace DummySmartPhones.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmartPhonesController : ControllerBase
    {
        private readonly ISmartPhonesService _smartPhonesService;
        public SmartPhonesController(ISmartPhonesService smartPhonesService)
        {
            _smartPhonesService = smartPhonesService;
        }
        [HttpGet(Name = "GetBestSmartPhone")]
        public IActionResult GetBestSmartPhone()
        {
            var data = _smartPhonesService.GetBestSmartPhone();
            return Ok(data);
        }
    }
}
