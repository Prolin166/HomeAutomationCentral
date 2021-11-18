using System.Collections.Generic;

namespace HomeAutomationCentral.Models
{
    public class AreaModel
    {
        public int AreaId { get; set; }
        public string Name { get; set; }
        public EndpointTypeModel EndpointType { get; set; }
        public int HostId { get; set; }
        public List<DeviceModel> Devices { get; set; }
    }

}
