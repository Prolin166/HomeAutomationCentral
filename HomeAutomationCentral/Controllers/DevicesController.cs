using HomeAutomationCentral.Models;
using HomeAutomationCentral.Business.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HomeAutomationCentral.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        // Dependency injection by controller
        public DevicesController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpPost]
        public IActionResult CreateDeviceManually([FromBody]DeviceModel device)
        {
            var success = _deviceService.CreateDevice(device);
            return StatusCode(success ? 200 : 400);
        }

        [HttpGet]
        public IActionResult GetAllDevices()
        {
           var result = JsonConvert.SerializeObject(_deviceService.GetDevices(), Formatting.Indented,
           new JsonSerializerSettings
           {
               ReferenceLoopHandling = ReferenceLoopHandling.Ignore
           });

            return Content(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetDeviceDetails(int id)
        {
            var result = JsonConvert.SerializeObject(_deviceService.GetDeviceDetails(id), Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Content(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDevice(int id)
        {
            var success = _deviceService.DeleteDevice(id);
            return StatusCode(success ? 200 : 400);
        }

        [HttpPut("{id}")]
        public IActionResult EditDevice(int id, [FromBody] DeviceModel device)
        {
            var result = JsonConvert.SerializeObject(_deviceService.EditDevice(id, device), Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Content(result);
        }
    }
}



