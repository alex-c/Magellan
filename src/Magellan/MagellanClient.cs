using Magellan.Models;
using Magellan.ServiceSelection;
using System;
using System.Collections.Generic;

namespace Magellan
{
    /// <summary>
    /// The Magellan client exposing service discovery and cofiguration functionality.
    /// </summary>
    public class MagellanClient
    {
        /// <summary>
        /// Default strategy to select a service instance from several available instances.
        /// </summary>
        private IServiceInstanceSelectionStrategy DefaultServiceInstanceSelectionStrategy { get; set; }

        /// <summary>
        /// Sets up the Magellan client with all needed configuration options.
        /// </summary>
        /// <param name="configuration">The configuration for the Magellan client.</param>
        public MagellanClient(MagellanClientConfiguration configuration)
        {
            //TODO: initialize Consul client
            throw new NotImplementedException();
        }

        /// <summary>
        /// Registers a service instance with the local Consul agent.
        /// </summary>
        /// <param name="service">Service to register.</param>
        public void RegisterServiceInstance(ServiceDeclaration service)
        {
            //TODO: implement RegisterServiceInstance
            throw new NotImplementedException();
        }

        /// <summary>
        /// Registers service instances with the local Consul client.
        /// </summary>
        /// <param name="services">Services to register.</param>
        public void RegisterServiceInstances(ICollection<ServiceDeclaration> services)
        {
            //TODO: implement RegisterServiceInstances
            throw new NotImplementedException();
        }

        /// <summary>
        /// Queries the local Consul agent for healthy instances of a given service and selects one such instance.
        /// </summary>
        /// <param name="query">Query to find services instances with.</param>
        /// <returns>Returns a service instance.</returns>
        public ServiceInstanceDescriptor GetServiceInstance(ServiceQuery query)
        {
            //TODO: implement QueryService
            throw new NotImplementedException();
        }
    }
}
