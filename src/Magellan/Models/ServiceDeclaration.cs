using System.Collections.Generic;

namespace Magellan.Models
{
    /// <summary>
    /// Specifies a service/service instance to declare. This is used to register a service instance with Consul.
    /// </summary>
    public class ServiceDeclaration
    {
        /// <summary>
        /// Identifies the service to declare.
        /// </summary>
        public string Service { get; set; }

        /// <summary>
        /// Host of the service instance to register.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Port of the service instance to register.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Tags associated with the service instance to register.
        /// </summary>
        public ISet<string> Tags { get; set; }
    }
}
