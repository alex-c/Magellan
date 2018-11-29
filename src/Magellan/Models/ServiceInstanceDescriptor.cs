namespace Magellan.Models
{
    /// <summary>
    /// Describes a service instance.
    /// </summary>
    public class ServiceInstanceDescriptor
    {
        public string Service { get; set; }
        public string InstanceId { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
