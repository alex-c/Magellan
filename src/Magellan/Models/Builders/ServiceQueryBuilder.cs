namespace Magellan.Models.Builders
{
    public class ServiceQueryBuilder
    {
        private string Service { get; }

        public ServiceQueryBuilder(string service)
        {
            Service = service;
        }

        public ServiceQuery Build()
        {
            return new ServiceQuery()
            {
                Service = Service
            };
        }
    }
}
