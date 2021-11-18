using HomeAutomationCentral.Business.Services;
using HomeAutomationCentral.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HomeAutomationCentral.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase
    {
        private IManagementHandler _managementHandler;

        // Dependency injection by controller
        public ManagementController(IManagementHandler managementHandler)
        {
            _managementHandler = managementHandler;
        }

        [HttpGet("area/{id}")]
        public IActionResult GetAreaStatus(int id, string result)
        {
            IActionResult obj = null;
            switch (result)
            {
                case "on":
                    //true = device on
                    obj = Ok(_managementHandler.GetAreaOnOff(id));
                    break;
                case "object":
                    var jsonResult = JsonConvert.SerializeObject(_managementHandler.GetAreaStatus(id), Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    obj = Content(jsonResult);
                    break;
            }
            return obj;
        }

        [HttpGet("device/{id}")]
        public IActionResult GetDeviceStatus(int id, string result)
        {
            IActionResult obj = null;
            switch (result)
            {
                case "on":
                    //true = device on
                    obj = Ok(_managementHandler.GetDeviceOnOff(id));
                    break;
                case "object":
                    var jsonResult = JsonConvert.SerializeObject(_managementHandler.GetDeviceStatus(id), Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    obj = Content(jsonResult);
                    break;
            }
            return obj;
        }

        [HttpPut("device/{id}/status")]
        public IActionResult SetDeviceStatus(int id, [FromBody] object device)
        {

            return Ok(_managementHandler.SetDeviceStatus(id, device));
        }

        [HttpPut("area/{id}/status")]
        public IActionResult SetAreaStatus(int id, [FromBody] object area)
        {
            return Ok(_managementHandler.SetAreaStatus(id, area));
        }

        [HttpPost("device/{id}")]
        public IActionResult Toggle(int id)
        {
            return Ok(_managementHandler.ToggleDevice(id));
        }        

        [HttpPost("area/{id}")]
        public IActionResult ToggleArea(int id)
        {
            return Ok(_managementHandler.ToggleArea(id));
        }

        [HttpPost("{type}")]
        public IActionResult AllDevicesOff(EndpointTypeModel type , string method)
        {
            return Ok(_managementHandler.SwitchAllDevicesOfType(type, method));
        }


    }
}



