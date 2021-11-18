namespace HomeAutomationCentral.Models
{ 
    public class DeviceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EndpointTypeModel EndpointType { get; set; }
        public int AreaId { get; set; }
        public string ExternalProviderId { get; set; }
        public int HostId { get; set; }
    }
}