using System;
using System.Runtime.Serialization;

namespace Magellan
{
    /// <summary>
    /// There is no healthy service instance available for the given service.
    /// </summary>
    public class NoAvailableServiceInstanceException : Exception
    {
        public NoAvailableServiceInstanceException() : this("There is no healthy service instance available for the given service.") { }

        public NoAvailableServiceInstanceException(string service) : base($"There is no healthy service instance available for the service '{service}'.") { }

        public NoAvailableServiceInstanceException(string service, Exception innerException) : base($"There is no healthy service instance available for the service '{service}'.", innerException) { }

        protected NoAvailableServiceInstanceException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
