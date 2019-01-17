using Consul;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Magellan.Tests
{
    [TestClass]
    public class MagellanClientTests
    {
        //Consul constants
        private const string CONSUL_HOST = "localhost";
        private const int CONSUL_PORT = 8500;

        //Clients
        private ConsulClient ConsulClient { get; }
        private MagellanClient MagellanClient { get; }

        //Test data
        private List<AgentServiceRegistration> Services { get; }

        /// <summary>
        /// Set up clients to test/test against and set up test data.
        /// </summary>
        public MagellanClientTests()
        {
            //Set up Consul client to test against
            ConsulClient = new ConsulClient(consulClientConfig =>
            {
                consulClientConfig.Address = new Uri($"http://{CONSUL_HOST}:{CONSUL_PORT}");
            });

            //Set up Magellan client to test
            MagellanClient = new MagellanClient(new MagellanClientConfiguration()
            {
                ConsulAgentHost = CONSUL_HOST,
                ConsulAgentPort = CONSUL_PORT
            });

            //Set up test data
            Services = new List<AgentServiceRegistration>()
            {
                new AgentServiceRegistration()
                {
                    Name = "test-service",
                    ID = "test-service-1",
                    Port = 6000
                },
                new AgentServiceRegistration()
                {
                    Name = "test-service",
                    ID = "test-service-2",
                    Port = 6000
                }
            };
        }

        /// <summary>
        /// Register services from test data.
        /// </summary>
        [TestInitialize]
        public void RegisterServices()
        {
            foreach (AgentServiceRegistration service in Services)
            {
                //Make sure the services are registered before executing any test
                var ignored = ConsulClient.Agent.ServiceRegister(service).Result;
            }
        }

        /// <summary>
        /// Deregisters services from test data.
        /// </summary>
        [TestCleanup]
        public void DeregisterServices()
        {
            foreach (AgentServiceRegistration service in Services)
            {
                var ignored = ConsulClient.Agent.ServiceDeregister(service.ID).Result;
            }

        }
        
        [TestMethod]
        public void TestMethod()
        {
            
        }
    }
}
