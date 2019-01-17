using Consul;
using Magellan.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
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
                    Port = 6001,
                },
                new AgentServiceRegistration()
                {
                    Name = "test-service",
                    ID = "test-service-3",
                    Port = 6002,
                    Check = new AgentServiceCheck()
                    {
                        HTTP = "http://168.255.255.255:7000",
                        Interval = new TimeSpan(0, 1, 0),
                        Status = HealthStatus.Critical
                    }
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

        /// <summary>
        /// Tests MagellanClient.GetServiceInstances.
        /// </summary>
        [TestMethod]
        public void GetAllInstancesOfAService()
        {
            //Query for service instances
            ICollection<ServiceInstanceDescriptor> serviceInstances = MagellanClient.GetServiceInstances(new ServiceInstanceQuery()
            {
                Service = "test-service"
            });

            //Expected service instances
            IEnumerable<AgentServiceRegistration> expectedInstances = Services.Where(s => s.Name == "test-service" && s.Check == null);

            //Check that the right amount of service instances was returned
            Assert.AreEqual(expectedInstances.Count(), serviceInstances.Count);

            //Check whether the right service instances were returned
            foreach (AgentServiceRegistration expectedInstance in expectedInstances)
            {
                Assert.IsTrue(serviceInstances.Where(si => si.InstanceId == expectedInstance.ID).Count() == 1);
            }
        }

        /// <summary>
        /// Tests MagellanClient.GetServiceInstances for an unknown service.
        /// </summary>
        [TestMethod]
        public void GetAllInstancesOfAnUnknownService()
        {
            ICollection<ServiceInstanceDescriptor> serviceInstances = MagellanClient.GetServiceInstances(new ServiceInstanceQuery()
            {
                Service = "super-service-of-doom"
            });

            Assert.AreEqual(0, serviceInstances.Count);
        }

        /// <summary>
        /// Tests MagellanClient.GetServiceInstance in the positive case.
        /// </summary>
        [TestMethod]
        public void GetAnInstanceOfAService()
        {
            //Query for a service instance
            ServiceInstanceDescriptor serviceInstance = MagellanClient.GetServiceInstance(new ServiceInstanceQuery()
            {
                Service = "test-service"
            });

            //Possible service instances
            IEnumerable<AgentServiceRegistration> possibleInstances = Services.Where(s => s.Name == "test-service" && s.Check == null);
            
            //Check whether a valid service instance was returned
            Assert.IsTrue(possibleInstances.Where(pi => pi.ID == serviceInstance.InstanceId).Count() == 1);
        }

        /// <summary>
        /// Tests MagellanClient.GetServiceInstance in the negative case.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NoAvailableServiceInstanceException))]
        public void GetAnInstanceOfAnUnknownService()
        {
            //Query for a service instance
            ServiceInstanceDescriptor serviceInstance = MagellanClient.GetServiceInstance(new ServiceInstanceQuery()
            {
                Service = "super-service-of-doom"
            });
        }
    }
}
