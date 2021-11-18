using HomeAutomationCentral.Models;

namespace HomeAutomationCentral.Business.Services
{
    public interface IManagementHandler
    {
        object GetDeviceStatus(int id);
        object GetAreaStatus(int id);
        bool GetDeviceOnOff(int id);
        bool GetAreaOnOff(int id);
        bool SetDeviceStatus(int id, object device);
        bool SetAreaStatus(int id, object area);
        bool ToggleDevice(int id);
        bool ToggleArea(int id);
        bool SwitchAllDevicesOfType(EndpointTypeModel deviceTye, string method);
        bool PressButton(int id);
    }
}
