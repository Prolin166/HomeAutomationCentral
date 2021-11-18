using HomeAutomationCentral.Business.Backgroundtasks;
using Microsoft.AspNetCore.Mvc;

namespace HomeAutomationCentral.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private HueUpdater _hueUpdater;

        // Dependency injection by controller
        public TaskController(HueUpdater hueUpdater)
        {
            _hueUpdater = hueUpdater;
        }

        [HttpPost("hueupdate")]
        public IActionResult HueUpdate()
        {
            return Ok(_hueUpdater.HueUpdateByController());
        }


    }
}



