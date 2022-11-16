﻿using DummySmartPhones.Business;
using Microsoft.AspNetCore.Mvc;

namespace DummySmartPhones.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmartPhonesConntroller : ControllerBase
    {
        private readonly SmartPhonesService _smartPhonesService;
        public SmartPhonesConntroller(SmartPhonesService smartPhonesService)
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
