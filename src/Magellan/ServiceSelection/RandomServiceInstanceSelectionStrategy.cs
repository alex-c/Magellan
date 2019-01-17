using Magellan.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Magellan.ServiceSelection
{
    /// <summary>
    /// Service selection strategy that selects a random service from several available instances.
    /// </summary>
    public class RandomServiceInstanceSelectionStrategy : IServiceInstanceSelectionStrategy
    {
        /// <summary>
        /// Generator of random integers that is used to randomly select a service instance.
        /// </summary>
        private Random RNG { get; set; }

        /// <summary>
        /// Sets up the service instance selection strategy.
        /// </summary>
        public RandomServiceInstanceSelectionStrategy()
        {
            RNG = new Random();
        }

        /// <summary>
        /// Selects a random service instance from several available instances.
        /// </summary>
        /// <returns></returns>
        public ServiceInstanceDescriptor SelectServiceInstance(ICollection<ServiceInstanceDescriptor> serviceInstances)
        {
            return serviceInstances.ElementAt(RNG.Next(0, serviceInstances.Count));
        }
    }
}
