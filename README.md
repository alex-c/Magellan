# Magellan

Magellan is a .NET Standard 2.1 library for services discovery using [Consul](https://www.consul.io/). It is not a full client for the Consul API, but rather a client offering opinionated methods for service discovery and configuration in a microservice architecture. It's goal is to use Consul to minimize the effort needed to connect and configure microservices in a distributed system.

## Status

Magellan is in early development.

## Model

Magellan assumes you are running several services in a distributed system, each of which potentially having numerous instances. It is designed for a system in which each host with potentially numerous services and instances runs one Consul agent. In the context of Magellan, the following vocabulary is used:

- **service:** A type of service, identified by a name (like `MyUserAuthenticationService`). A service can have several instances on the same or different hosts.
- **service instance:** A specific instance of a given service. It is identified by the service name, as well as the IP address and port it is available at.
- **healthy service:** A service which has at least one healthy service instance.
- **healthy service instance:** A service instance which passes all Consul health checks associated with it.
- **local agent**: The Consul agent running on the host being considered or the host of the service instance being considered.

## Features

Magellan allows to:

- register service instances with health checks
- check health of services and service instances
- query for an instance of a service to use
