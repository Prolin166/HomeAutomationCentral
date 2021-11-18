using HomeAutomationCentral.Models;
using HomeAutomationCentral.Domain.Entities;
using System.Collections.Generic;

namespace HomeAutomationCentral.Business.HWEndpoints.Contacts
{
    public interface IEndpoint
    {
        object GetStatus(DeviceModel deviceModel);
        object GetStatus(AreaModel areaModel);
        bool SetStatus(DeviceModel deviceModel, object deviceBody);
        bool SetStatus(AreaModel areaModel, object areaBody);
        bool GetOnOff(DeviceModel deviceModel);
        bool GetOnOff(AreaModel areaModel);
        bool TurnOn(DeviceModel deviceModel);
        bool TurnOn(AreaModel areaModel);
        bool TurnOn(List<DeviceModel> list);
        bool TurnOff(List<DeviceModel> list);
        bool TurnOff(DeviceModel deviceModel);
        bool TurnOff(AreaModel areaModel);
        bool PressButton(DeviceModel deviceModel);
    }
}
