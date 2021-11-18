using HomeAutomationCentral.Models;
using System.Collections.Generic;

namespace HomeAutomationCentral.Business.Services.Contracts
{
    public interface IAreaService
    {
        List<AreaModel> GetAreas();
        AreaModel GetAreaDetails(int id);
        bool CreateArea(AreaModel areaModel);
        bool UpdateArea(AreaModel areaModel);
        AreaModel EditArea(int id, AreaModel areaModel);
        bool DeleteAreaById(int id);
        List<DeviceModel> GetDevicesByAreaId(int id);
    }
}
