using SmartPhones.Business;
using Microsoft.AspNetCore.Mvc;

namespace DummySmartPhones.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmartPhonesConntroller : ControllerBase
    {
        private readonly ISmartPhonesService _smartPhonesService;
        public SmartPhonesConntroller(ISmartPhonesService smartPhonesService)
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
