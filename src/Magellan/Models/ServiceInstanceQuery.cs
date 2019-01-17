using System.Collections.Generic;

namespace Magellan.Models
{
    /// <summary>
    /// A query used to retrieve available instances of a given service.
    /// </summary>
    public class ServiceInstanceQuery
    {
        /// <summary>
        /// Identifies the service to retrieve available instances for.
        /// </summary>
        public string Service { get; set; }

        /// <summary>
        /// Tags used to filter available service instances with.
        /// </summary>
        public HashSet<string> Tags { get; set; } = new HashSet<string>();
    }
}
