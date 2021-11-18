using HomeAutomationCentral.Business.HWEndpoints.Contacts;
using HomeAutomationCentral.Models;
using HomeAutomationCentral.Domain.Entities;
using HomeAutomationCentral.Endpoint.HWEndpoints.Options;
using HomeAutomationCentral.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HomeAutomationCentral.Business
{
    public class EndpointFactory
    {
        private readonly ILogger<HueEndpoint> _hueLogger;

        private readonly ILogger<ESPEndpoint> _espLogger;

        private readonly IOptions<ESPEndpointOptions> _espEndpointOptions;

        private readonly IOptions<HueEndpointOptions> _hueEndpointOptions;
        public EndpointFactory(IOptions<ESPEndpointOptions> espEndpointOptions, 
                               IOptions<HueEndpointOptions> hueEndpointOptions, 
                               ILogger<HueEndpoint> hueLogger,
                               ILogger<ESPEndpoint> espLogger)
        {
            _espEndpointOptions = espEndpointOptions;
            _hueEndpointOptions = hueEndpointOptions;
            _hueLogger = hueLogger;
            _espLogger = espLogger;
        }

        public IEndpoint GetEndpoinByDeviceType(EndpointTypeModel deviceType)
        {
            switch (deviceType)
            {
                case EndpointTypeModel.Hue:
                    return new HueEndpoint(_hueEndpointOptions, _hueLogger);

                case EndpointTypeModel.ESP:
                    return new ESPEndpoint(_espEndpointOptions, _espLogger);
                default:
                    return null;
            }
        }

    }
}
