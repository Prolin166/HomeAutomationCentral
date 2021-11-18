namespace HomeAutomationCentral.Domain.Entities
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HostId { get; set; }
        public string ExternalProviderId { get; set; }
        public EndpointType EndpointType { get; set; }
        public virtual Area Area { get; set; }
        public int? AreaId { get; set; }
    }
}