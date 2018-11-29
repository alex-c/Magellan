using Magellan.Models;
using Magellan.Models.Builders;

namespace Magellan
{
    /// <summary>
    /// The Magellan client exposing service discovery and cofiguration functionality.
    /// </summary>
    public class MagellanClient
    {
        /// <summary>
        /// Sets up the Magellan client with all needed configuration options.
        /// </summary>
        /// <param name="configuration">The configuration for the Magellan client.</param>
        public MagellanClient(MagellanClientConfiguration configuration)
        {
        }

        #region Builders

        public ServiceDeclarationBuilder CreateServiceDeclaration(string service)
        {
            return new ServiceDeclarationBuilder(service);
        }

        public ServiceQueryBuilder CreateServiceQuery(string service)
        {
            return new ServiceQueryBuilder(service);
        }

        #endregion

        public void RegisterService() { }
        public void RegisterServices() { }

        public ServiceInstanceDescriptor QueryService(ServiceQuery query)
        {
            //TODO: Query Consul agent for healthy service instances
            //TODO: Apply constraints
            //TODO: Service selection

            return null;
        }

        public void QueryServices() { }
    }
}
