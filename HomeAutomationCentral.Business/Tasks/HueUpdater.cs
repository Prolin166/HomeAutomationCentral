using HomeAutomationCentral.Business.Services.Contracts;
using HomeAutomationCentral.Models;
using HomeAutomationCentral.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeAutomationCentral.Business.Backgroundtasks
{
    public class HueUpdater
    {
        private readonly IHueEndpoint _hueEndpoint;
        private readonly ILogger<HueUpdater> _logger;
        private readonly IServiceScopeFactory _services;

       public HueUpdater(IServiceScopeFactory serviceFactory, ILogger<HueUpdater> logger, IHueEndpoint hueEndpoint)
        {
            _logger = logger;
            _services = serviceFactory;
            _hueEndpoint = hueEndpoint;
        }

        public bool HueUpdateByController()
        {
            try
            {
                UpdateAreas();
                UpdateDevices();

                return true;
            }
            catch
            {
                return false;
            }

        }

        private void UpdateAreas()
        {
            try
            {
                using (var scope = _services.CreateScope())
                {
                    var areaService = scope.ServiceProvider.GetService<IAreaService>();

                    var hueAreas = _hueEndpoint.GetAreas();
                    foreach (var hueArea in hueAreas)
                    {
                        var existingArea = areaService.GetAreas().FirstOrDefault(area => area.HostId == hueArea.ID);
                        AreaModel newArea = new AreaModel()
                        {
                            Name = hueArea.Name,
                            HostId = hueArea.ID,
                            EndpointType = EndpointTypeModel.Hue,
                        };

                        if (existingArea == null)
                        {
                            areaService.CreateArea(newArea); //signalR
                        }
                        else
                        {
                            newArea.AreaId = existingArea.AreaId;
                            newArea.Devices = new List<DeviceModel>();
                            if (existingArea.Equals(newArea))
                                areaService.EditArea(existingArea.AreaId, newArea);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        private void UpdateDevices()
        {
            try
            {
                using (var scope = _services.CreateScope())
                {
                    var deviceService = scope.ServiceProvider.GetService<IDeviceService>();

                    var hueDevices = _hueEndpoint.GetDevices();
                    foreach (var huedevice in hueDevices)
                    {
                        var existingDevice = deviceService.GetDevices().FirstOrDefault(device => device.HostId == huedevice.ID);


                        DeviceModel newDevice = new DeviceModel()
                        {
                            EndpointType = EndpointTypeModel.Hue,
                            ExternalProviderId = huedevice.Uniqueid,
                            Name = huedevice.Name,
                            HostId = huedevice.ID,
                        };

                        if (existingDevice == null)
                        {
                            deviceService.CreateDevice(newDevice); //signalR
                        }
                        else
                        {
                            newDevice.Id = existingDevice.Id;
                            newDevice.AreaId = existingDevice.AreaId;
                            if (existingDevice.Equals(newDevice))
                                deviceService.EditDevice(existingDevice.Id, newDevice);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}

