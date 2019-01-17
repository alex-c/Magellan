using Consul;
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
        private ConsulClient Consul { get; }

        /// <summary>
        /// Default strategy to select a service instance from several available instances.
        /// </summary>
        private IServiceInstanceSelectionStrategy DefaultServiceInstanceSelectionStrategy { get; }

        /// <summary>
        /// Sets up the Magellan client with all needed configuration options.
        /// </summary>
        /// <param name="configuration">The configuration for the Magellan client.</param>
        public MagellanClient(MagellanClientConfiguration configuration)
        {
            //Set default service selection strategy
            DefaultServiceInstanceSelectionStrategy = InitializeServiceInstanceSelectionStrategy(configuration.DefaultServiceInstanceSelectionStrategy);

            //Initialize Consul client
            Consul = new ConsulClient(consulClientConfig =>
            {
                consulClientConfig.Address = new Uri($"http://{configuration.ConsulAgentHost}:{configuration.ConsulAgentPort.ToString()}");
            });
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
        public ServiceInstanceDescriptor GetServiceInstance(ServiceInstanceQuery query)
        {
            //TODO: implement QueryService
            throw new NotImplementedException();
        }

        #region Privat helper methods

        /// <summary>
        /// Initializes a service instance selection strategy object.
        /// </summary>
        /// <param name="strategyType">Type of strategy to initialize an object for.</param>
        /// <returns>Returns a service selection strategy.</returns>
        private IServiceInstanceSelectionStrategy InitializeServiceInstanceSelectionStrategy(ServiceInstanceSelectionStrategy strategyType)
        {
            IServiceInstanceSelectionStrategy strategy = null;

            switch (strategyType)
            {
                case ServiceInstanceSelectionStrategy.RandomServiceInstanceSelection:
                    strategy = new RandomServiceInstanceSelectionStrategy();
                    break;
                default:
                    throw new NotImplementedException($"No implementation available for service instance selection strategy {strategyType}.");
            }

            return strategy;
        }

        #endregion
    }
}
