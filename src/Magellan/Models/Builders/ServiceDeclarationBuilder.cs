using System.Collections.Generic;

namespace Magellan.Models.Builders
{
    public class ServiceDeclarationBuilder
    {
        private string Service { get; }

        private string Host { get; set; }

        private int Port { get; set; }

        private ISet<string> Tags { get; set; }

        public ServiceDeclarationBuilder(string service)
        {
            Service = service;
            Tags = new HashSet<string>();
        }

        #region Fluent API

        public ServiceDeclarationBuilder SetHost(string host)
        {
            Host = host;
            return this;
        }

        public ServiceDeclarationBuilder SetPort(int port)
        {
            Port = port;
            return this;
        }

        public ServiceDeclarationBuilder AddTag(string tag)
        {
            Tags.Add(tag);
            return this;
        }

        #endregion

        public ServiceDeclaration Build()
        {
            return new ServiceDeclaration()
            {
                Service = Service,
                Host = Host,
                Port = Port,
                Tags = Tags
            };
        }
    }
}
