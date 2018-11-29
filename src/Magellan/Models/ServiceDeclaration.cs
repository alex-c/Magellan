using System.Collections.Generic;

namespace Magellan.Models
{
    /// <summary>
    /// Specifies a service/service instance to declare. This is used to register a service instance with Consul.
    /// </summary>
    public class ServiceDeclaration
    {
        public string Service { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public ISet<string> Tags { get; set; }
    }
}
