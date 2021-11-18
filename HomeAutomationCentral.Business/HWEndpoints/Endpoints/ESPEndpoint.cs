using HomeAutomationCentral.Business.HWEndpoints.Contacts;
using HomeAutomationCentral.Models;
using HomeAutomationCentral.Endpoint.HWEndpoints.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace HomeAutomationCentral.Services
{
    public class ESPEndpoint : IEndpoint
    {
        private readonly IOptions<ESPEndpointOptions> _espEndpointOptions;

        private readonly ILogger<ESPEndpoint> _logger;
        public ESPEndpoint(IOptions<ESPEndpointOptions> espEndpointOptions, ILogger<ESPEndpoint> logger)
        {
            _logger = logger;
            _espEndpointOptions = espEndpointOptions;
        }

        public bool PressButton(DeviceModel deviceModel)
        {
            throw new NotImplementedException();
        }

        public bool TurnOff(DeviceModel deviceModel)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync("http://192.168.1.154/cm?cmnd=Power%20off").Result;
                string responseContent = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseContent);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Fehler: {0} ", e.Message);
            }

            return true;
        }

        public bool TurnOn(DeviceModel deviceModel)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync("http://192.168.1.154/cm?cmnd=Power%20On").Result;
                string responseContent = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseContent);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Fehler: {0} ", e.Message);
            }
            return true;
        }

        public bool TurnOn(AreaModel areaModel)
        {
            throw new NotImplementedException();
        }

        public bool TurnOff(AreaModel areaModel)
        {
            throw new NotImplementedException();
        }

        public bool SetStatus(AreaModel areaModel, object areaBody)
        {
            throw new NotImplementedException();
        }

        public bool TurnOn(EndpointTypeModel type)
        {
            throw new NotImplementedException();
        }

        public bool TurnTypeOff(EndpointTypeModel type)
        {
            throw new NotImplementedException();
        }

        public object GetStatus(DeviceModel deviceModel)
        {
            throw new NotImplementedException();
        }

        public object GetStatus(AreaModel areaModel)
        {
            throw new NotImplementedException();
        }

        public bool GetOnOff(DeviceModel deviceModel)
        {
            throw new NotImplementedException();
        }

        public bool GetOnOff(AreaModel areaModel)
        {
            throw new NotImplementedException();
        }

        public bool SetStatus(DeviceModel deviceModel, object deviceBody)
        {
            throw new NotImplementedException();
        }

        public bool TurnOff(EndpointTypeModel type)
        {
            throw new NotImplementedException();
        }

        public bool TurnOn(List<DeviceModel> list)
        {
            throw new NotImplementedException();
        }

        public bool TurnOff(List<DeviceModel> list)
        {
            throw new NotImplementedException();
        }
    }
}
