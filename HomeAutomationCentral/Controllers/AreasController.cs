using HomeAutomationCentral.Models;
using HomeAutomationCentral.Business.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HomeAutomationCentral.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly IAreaService _areaService;

        // Dependency injection by controller
        public AreasController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpPost]
        public IActionResult CreateArea([FromBody] AreaModel areaModel)
        {
            var success = _areaService.CreateArea(areaModel);
            return StatusCode(success ? 200 : 400);
        }

        [HttpGet]
        public IActionResult GetAreas()
        {
            var result = JsonConvert.SerializeObject(_areaService.GetAreas(), Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Content(result);
        }

        [HttpGet("getdevicesbyarea/{id}")]
        public IActionResult GetDevicesByAreaId(int id)
        {
            var result = JsonConvert.SerializeObject(_areaService.GetDevicesByAreaId(id), Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Content(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAreaDetails(int id)
        {
            var result = JsonConvert.SerializeObject(_areaService.GetAreaDetails(id), Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Content(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArea(int id)
        {
            var success = _areaService.DeleteAreaById(id);
            return StatusCode(success ? 200 : 400);
        }

        [HttpPut("{id}")]
        public IActionResult EditArea(int id, [FromBody] AreaModel areaModel)
        {
            var result = JsonConvert.SerializeObject(_areaService.EditArea(id, areaModel), Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Content(result);
        }


    }
}



