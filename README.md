# Bitflux

Library for [Real-time communication](https://en.wikipedia.org/wiki/Real-time_communication) based on [ASP.NET](https://dotnet.microsoft.com/en-us/apps/aspnet). Inspired by [SignalR](https://docs.microsoft.com/en-us/aspnet/core/signalr/introduction).

> :warning: Currently, the library is not production ready. The API may change at any time.

## Features

### Hubs

Node between connected clients that provides tools for communication between them.

- Grouping clients;
- Events of Adding/Removing clients;
- Events of Adding/Removing clients from groups;

### Workers

Representative of a specific Hub that serves client invocations.

### Handlers

The usual methods of a worker for handling client invocations.

- Can be renamed;
- Automatic arguments binding;
- Can be invoked in different ways: with and without interest in a result;

### Filters

Allows to perform some operations before and after a handler invocation.

- Applies to a hub, worker or handler;
- Workers can avoid applying specific hub filters;
- Handlers can avoid applying specific hub and worker filters;

### Configuration

- Separate configuration for a specific hub;
- Pipeline configuration for a specific hub endpoint;

### Mapping

- Multiple hubs per different endpoints;
- Multiple endpoints per a hub;
- Multiple workers per a hub;

### Communication

Communication is happening through a specific transport ([WebSocket](src/Yellfage.Bitflux.Receptions.WebSockets), Server Sent Events, HTTP polling/long polling, etc) by using a specific protocol ([Json](src/Yellfage.Bitflux.Protocols.NewtonsoftJson), MessagePack, Xml, etc). Server just provides list of supporting transports and protocols. Choosing transport and protocol is happening on a client-side during a handshake.

- Custom transports and protocols;
- Multiple transports and protocols;

### Bussing

Bussing is happening through a specific bus ([Local](src/Yellfage.Bitflux/Interior/Bussing/Bus.cs), Redis, RabbitMQ, Apache Kafka, etc).

- Custom buses;

### Caching

Caching is happening by using a specific cache provider ([Local](src/Yellfage.Bitflux/Interior/Caching/Cache.cs), Redis, Memcached, etc).

- Custom caches;
- Caching per a hub;
- Caching per a client;

## Usage

- Check out the static [sample](samples/Yellfage.Bitflux.Sample.Echo)
