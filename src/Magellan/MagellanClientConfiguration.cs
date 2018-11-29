namespace Magellan
{
    /// <summary>
    /// Configuration for the Magellan client.
    /// </summary>
    public class MagellanClientConfiguration
    {
        /// <summary>
        /// Address or name of the host the Consul agent to connect to is running on. Should be the host of the service using Magellan.
        /// </summary>
        public string ConsulAgentHost { get; set; } = "localhost";

        /// <summary>
        /// Port of the HTTP interface of the Consul agent to connect to.
        /// </summary>
        public int ConsulAgentPort { get; set; } = 8500;
    }
}
