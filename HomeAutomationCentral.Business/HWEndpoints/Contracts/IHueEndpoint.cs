using HomeAutomationCentral.Models;
using System.Collections.Generic;

namespace HomeAutomationCentral.Services.Contracts
{
    public interface IHueEndpoint
    {
        List<HueLightModel> GetDevices();

        List<HueAreaModel> GetAreas();
    } 
}
