using Magellan.Models;

namespace Magellan.ServiceSelection
{
    /// <summary>
    /// Represents a constraint used to filter healthy service instances during service instance selection.
    /// </summary>
    public interface IServiceConstraint
    {
        /// <summary>
        /// Checks whether a service instance satisifies this constraint.
        /// </summary>
        /// <param name="descriptor">Descriptor of the service instance to check.</param>
        /// <returns>Returns whether the service instance satisfies this constraint.</returns>
        bool ServiceInstanceSatifiesConstraint(ServiceInstanceDescriptor descriptor);
    }
}
