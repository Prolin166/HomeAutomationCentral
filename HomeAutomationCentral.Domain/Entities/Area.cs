using System.Collections.Generic;

namespace HomeAutomationCentral.Domain.Entities
{
    public class Area 
    {
        public int AreaId { get; set; }
        public string Name { get; set; }
        public EndpointType EndpointType { get; set; }
        public int HostId { get; set; }
        public virtual List<Device> Devices { get; set; }
    }

}
