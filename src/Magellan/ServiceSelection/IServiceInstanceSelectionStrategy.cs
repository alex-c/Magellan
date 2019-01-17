using Magellan.Models;

namespace Magellan.ServiceSelection
{
    /// <summary>
    /// A service selection strategy allows to select a service instance from several available instances.
    /// </summary>
    public interface IServiceInstanceSelectionStrategy
    {
        /// <summary>
        /// Selects a service instance from several available instances.
        /// </summary>
        /// <returns>Returns the selected service instance.</returns>
        ServiceInstanceDescriptor SelectServiceInstance();
    }
}
