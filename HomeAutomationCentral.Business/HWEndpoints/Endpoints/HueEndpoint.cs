using HomeAutomationCentral.Models;
using GeneralPackage;
using HomeAutomationCentral.Business.HWEndpoints.Contacts;
using HomeAutomationCentral.Models;
using HomeAutomationCentral.Endpoint.HWEndpoints.Options;
using HomeAutomationCentral.Services.Contracts;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace HomeAutomationCentral.Services
{
    public class HueEndpoint : IEndpoint, IHueEndpoint
    {
        private JsonRestService _client;

        private string _connectionString;

        IOptions<HueEndpointOptions> _hueEndpointOptions;

        ILogger<HueEndpoint> _logger;

        public HueEndpoint(IOptions<HueEndpointOptions> hueEndpointOptions, ILogger<HueEndpoint> logger)
        {
            _logger = logger;
            _hueEndpointOptions = hueEndpointOptions;
            EndpointAddr = _hueEndpointOptions.Value.EndpointAddress;
            ApiToken = _hueEndpointOptions.Value.ApiToken;
            _connectionString = string.Format("http://{0}/api/{1}/", EndpointAddr, ApiToken);
            _client = new JsonRestService(_connectionString);
        }

        public string EndpointAddr { get; set; }
        public string ApiToken { get; set; }

        public object GetStatus(DeviceModel deviceModel)
        {
            var response = _client.GetStaticJsonRestAnswer<HueLightModel>("lights/" + deviceModel.HostId, Method.GET);
            bool status = response.State.On;

            _logger.LogInformation("Status von " + deviceModel.Name + " abgefragt (Status: " + status.ToString() + ")");

            return response;
        }

        public object GetStatus(AreaModel areaModel)
        {
            var response = _client.GetStaticJsonRestAnswer<HueAreaModel>("groups/" + areaModel.HostId, Method.GET);
            bool status = response.State.AnyOn;

            _logger.LogInformation("Status von " + areaModel.Name + " abgefragt (Status: " + status.ToString() + ")");

            return response;
        }

        public bool GetOnOff(DeviceModel deviceModel)
        {
            var response = _client.GetStaticJsonRestAnswer<HueLightModel>("lights/" + deviceModel.HostId, Method.GET);
            bool status = response.State.On;

            _logger.LogInformation("Status von " + deviceModel.Name + " abgefragt (Status: " + status.ToString() + ")");

            return status;
        }

        public bool GetOnOff(AreaModel areaModel)
        {
            bool status = false;
            var response = _client.GetStaticJsonRestAnswer<HueAreaModel>("groups/" + areaModel.HostId, Method.GET);

            if (response.State.AllOn || response.State.AnyOn)
                status = true;

            _logger.LogInformation("Status von " + areaModel.Name + " abgefragt (Status: " + status.ToString() + ")");

            return status;
        }

        public bool SetStatus(DeviceModel deviceModel, object deviceBody)
        {
            try
            {
                var data = JsonConvert.DeserializeObject<HueLightStateModel>(deviceBody.ToString());
                _client.SetStaticJsonRestRequest("lights/" + deviceModel.HostId + "/state", data, Method.PUT);
                return true;
            }
            catch
            {
                _logger.LogError(deviceModel.Name + ": Status konnte nicht gesetzt werden.)");
                return false;
            }
        }
        public bool SetStatus(AreaModel areaModel, object areaBody)
        {
            try
            {
                var data = JsonConvert.DeserializeObject<HueAreaActionModel>(areaBody.ToString());
                _client.SetStaticJsonRestRequest("groups/" + areaModel.HostId + "/action", data, Method.PUT);
                return true;
            }
            catch
            {
                _logger.LogError(areaModel.Name + ": Status konnte nicht gesetzt werden.)");
                return false;
            }
        }
        
        public bool TurnOn(List<DeviceModel> list)
        {
            try
            {
                foreach (var device in list)
                {
                    var state = new HueLightStateOnModel();
                    state.On = true;
                    _client.SetStaticJsonRestRequest("lights/" + device.HostId + "/state", state, Method.PUT);
                    _logger.LogInformation(device.Name + "-Status: On = FALSE)");
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool TurnOn(AreaModel areaModel)
        {
            try
            {
                var state = new HueAreaActionOnModel();
                state.On = true;
                _client.SetStaticJsonRestRequest("groups/" + areaModel.HostId + "/action", state, Method.PUT);
                _logger.LogInformation(areaModel.Name + "-Status: On = TRUE)");

                return true;
            }
            catch
            {
                _logger.LogError(areaModel.Name + ": Status (on = TRUE) konnte nicht gesetzt werden))");
                return false;
            }
        }
        public bool TurnOn(DeviceModel deviceModel)
        {
            try
            {
                var state = new HueLightStateOnModel();
                state.On = true;
                _client.SetStaticJsonRestRequest("lights/" + deviceModel.HostId + "/state", state, Method.PUT);
                _logger.LogInformation(deviceModel.Name + "-Status: On = TRUE)");

                return true;
            }
            catch
            {
                _logger.LogError(deviceModel.Name + ": Status (on = TRUE) konnte nicht gesetzt werden))");
                return false;
            }
        }

        public bool TurnOff(List<DeviceModel> list)
        {
            try
            {
                foreach (var device in list)
                {
                    var state = new HueLightStateOnModel();
                    state.On = false;
                    _client.SetStaticJsonRestRequest("lights/" + device.HostId + "/state", state, Method.PUT);
                    _logger.LogInformation(device.Name + "-Status: On = FALSE)");
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool TurnOff(DeviceModel deviceModel)
        {
            try
            {
                var state = new HueLightStateOnModel();
                state.On = false;
                _client.SetStaticJsonRestRequest("lights/" + deviceModel.HostId + "/state", state, Method.PUT);
                _logger.LogInformation(deviceModel.Name + "-Status: On = FALSE)");

                return true;
            }
            catch
            {
                _logger.LogError(deviceModel.Name + ": Status (on = FALSE) konnte nicht gesetzt werden))");
                return false;
            }
        }

        public bool TurnOff(AreaModel areaModel)
        {
            try
            {
                var state = new HueAreaActionOnModel();
                state.On = false;
                _client.SetStaticJsonRestRequest("groups/" + areaModel.HostId + "/action", state, Method.PUT);
                _logger.LogInformation(areaModel.Name + "-Status: On = FALSE)");

                return true;
            }
            catch
            {
                _logger.LogError(areaModel.Name + ": Status (on = FALSE) konnte nicht gesetzt werden))");
                return false;
            }
        }

        public bool PressButton(DeviceModel device)
        {
            throw new System.NotImplementedException();
        }

        public List<HueLightModel> GetDevices()
        {
            var list = new List<HueLightModel>();
            var result = _client.GetStaticJsonRestAnswer<Dictionary<int, HueLightModel>>("lights", Method.GET);
            foreach (KeyValuePair<int, HueLightModel> item in result)
            {
                var element = item.Value;
                element.ID = item.Key;
                list.Add(element);
            }
            _logger.LogInformation("Geräteliste aus HueBridge abgefragt)");
            return list;
        }

        public List<HueAreaModel> GetAreas()
        {
            var list = new List<HueAreaModel>();
            var result = _client.GetStaticJsonRestAnswer<Dictionary<int, HueAreaModel>>("groups", Method.GET);
            foreach (KeyValuePair<int, HueAreaModel> item in result)
            {
                var element = item.Value;
                element.ID = item.Key;
                list.Add(element);
            }
            _logger.LogInformation("Bereichsliste aus HueBridge abgefragt)");

            return list;
        }

    }
}
