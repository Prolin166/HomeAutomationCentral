using HomeAutomationCentral.Models;
using System.Collections.Generic;

namespace HomeAutomationCentral.Business.Services.Contracts
{
    public interface IDeviceService
    {
        List<DeviceModel> GetDevices();
        DeviceModel GetDeviceDetails(int id); 
        bool CreateDevice(DeviceModel device);
        bool DeleteDevice(int id);
        void UpdateDevices(List<DeviceModel> devices);
        DeviceModel EditDevice(int id, DeviceModel device);
    }
}
