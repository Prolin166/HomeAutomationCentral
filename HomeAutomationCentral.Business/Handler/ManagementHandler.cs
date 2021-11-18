using HomeAutomationCentral.Models;
using HomeAutomationCentral.Business.Services.Contracts;
using System.Collections.Generic;

namespace HomeAutomationCentral.Business.Services
{
    public class ManagementHandler : IManagementHandler
    {
        EndpointFactory _endpointFactory;

        private IDeviceService _deviceService;

        private IAreaService _areaService;

        public ManagementHandler(EndpointFactory endpointFactory, IDeviceService deviceService, IAreaService areaService)
        {
            _endpointFactory = endpointFactory;
            _deviceService = deviceService;
            _areaService = areaService;
        }
        public object GetDeviceStatus(int id)
        {
            try
            {
                var deviceModel = _deviceService.GetDeviceDetails(id);
                var endPoint = _endpointFactory.GetEndpoinByDeviceType(deviceModel.EndpointType);

                object status = endPoint.GetStatus(deviceModel);
                return status;
            }
            catch
            {
                return false;
            }
        }

        public object GetAreaStatus(int id)
        {
            try
            {
                var areaModel = _areaService.GetAreaDetails(id);
                var endPoint = _endpointFactory.GetEndpoinByDeviceType(areaModel.EndpointType);

                object status = endPoint.GetStatus(areaModel);
                return status;
            }
            catch
            {
                return false;
            }
        }

        public bool GetDeviceOnOff(int id)
        {
            try
            {
                var deviceModel = _deviceService.GetDeviceDetails(id);
                var endPoint = _endpointFactory.GetEndpoinByDeviceType(deviceModel.EndpointType);

                bool status = endPoint.GetOnOff(deviceModel);
                return status;
            }
            catch
            {
                return false;
            }
        }
        public bool GetAreaOnOff(int id)
        {
            try
            {
                var areaModel = _areaService.GetAreaDetails(id);
                var endPoint = _endpointFactory.GetEndpoinByDeviceType(areaModel.EndpointType);

                bool status = endPoint.GetOnOff(areaModel);
                return status;
            }
            catch
            {
                return false;
            }
        }
        public bool SetDeviceStatus(int id, object device)
        {
            try
            {
                if (id != 000) // 000 = Input without Device ID, Settings are for Host Device
                {
                    var deviceModel = _deviceService.GetDeviceDetails(id);
                    var endPoint = _endpointFactory.GetEndpoinByDeviceType(deviceModel.EndpointType);
                    bool status = endPoint.SetStatus(deviceModel, device);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SetAreaStatus(int id, object area)
        {
            try
            {
                if (id != 000) // 000 = Input without Device ID, Settings are for Host Device
                {
                    var areaModel = _areaService.GetAreaDetails(id);
                    var endPoint = _endpointFactory.GetEndpoinByDeviceType(areaModel.EndpointType);
                    bool status = endPoint.SetStatus(areaModel, area);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ToggleDevice(int id)
        {
            try
            {
                var deviceModel = _deviceService.GetDeviceDetails(id);
                var endPoint = _endpointFactory.GetEndpoinByDeviceType(deviceModel.EndpointType);
                bool status = endPoint.GetOnOff(deviceModel);

                if (status)
                    endPoint.TurnOff(deviceModel);
                else
                    endPoint.TurnOn(deviceModel);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ToggleArea(int id)
        {
            try
            {
                var areaModel = _areaService.GetAreaDetails(id);
                var endPoint = _endpointFactory.GetEndpoinByDeviceType(areaModel.EndpointType);
                bool status = endPoint.GetOnOff(areaModel);

                if (status)
                    endPoint.TurnOff(areaModel);
                else
                    endPoint.TurnOn(areaModel);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SwitchAllDevicesOfType(EndpointTypeModel type, string method)
        {

            try
            {
                var devicelist = _deviceService.GetDevices().FindAll(deviceType => deviceType.EndpointType == type);
                var endPoint = _endpointFactory.GetEndpoinByDeviceType(type);

                if (method == "on")
                { 
                    endPoint.TurnOn(devicelist);
                }
                else
                {
                    endPoint.TurnOff(devicelist);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool PressButton(int id)
        {
            try
            { 

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
