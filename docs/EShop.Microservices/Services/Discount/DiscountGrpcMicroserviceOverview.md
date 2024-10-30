# Discount.Grpc Microservices

The **Discount.Grpc Microservice** is designed to facilitate high-performance gRPC-based inter-service communication within a microservices architecture, specifically between the Discount and Basket microservices. This service utilizes several modern technologies and architectures to ensure efficient data handling and CRUD operations.

## Key Features

- **ASP.NET gRPC API application**  
  The Discount microservice is developed using ASP.NET Core's gRPC framework, providing high-performance RPC capabilities.

- **High Performance Inter-Service gRPC Communication**  
  This microservice enables efficient communication between **Discount** and **Basket** services by leveraging gRPC’s low-latency communication protocol.

- **gRPC Communications with Proto Files for CRUD Operations**  
  All data contracts and service endpoints are defined using **Proto files** to ensure consistent data structures for CRUD operations across services.

- **Exposing gRPC Services with Protobuf Message**  
  The service uses **Protocol Buffers (Protobuf)** to serialize structured data, which is efficient and language-neutral, making it ideal for inter-service communication.

- **SQLite Database Connection and Containerization**  
  The Discount service is connected to an **SQLite database** for efficient data storage, and it is fully containerized for scalability and easy deployment.

- **Entity Framework Core ORM with SQLite Data Provider**  
  By using **Entity Framework Core** along with the **SQLite Data Provider**, the service benefits from simplified data access, automated migrations, and high performance in managing relational data.

- **N-Layer Architecture Implementation**  
  The service adheres to an **N-layer architecture**, separating concerns into layers (e.g., UI, Business, Data Access) for better maintainability and scalability.

- **Containerized Discount Microservice with Docker Compose**  
  The entire Discount microservice, including the SQLite database, is containerized using Docker, with configurations managed by **Docker Compose** for multi-container orchestration.

## Use Case: Add Item into Shopping Cart (SC)

When a client adds an item into the shopping cart, the **Basket microservice** will consume this Discount gRPC service to get the latest discount on that product item.

## Main Idea: Optimize Performance

The primary goal of the Discount.Grpc microservice is to be as performant as possible by:
- **Achieving maximum performance** and reducing service invocation time.
- **Ensuring fast response times** so the Discount microservice can handle synchronous calls efficiently from the Basket service.

## Internal Architecture

The internal architecture follows an N-layer model:
- **Application Layer**: Contains the business logic and processing of discount operations.
- **UI Layer**: Exposes endpoints for gRPC clients.
- **Data Access Layer**: Handles data persistence to the SQLite database via Entity Framework.

This architecture promotes code reusability, maintainability, and separation of concerns.

## Technology Stack

- **.NET Core 8**: Used to build the gRPC microservice.
- **gRPC and Protobuf**: Used for defining and handling high-performance RPC calls.
- **SQLite**: Lightweight database for storing discount data.
- **Entity Framework Core**: Simplifies data access and provides an ORM for interacting with SQLite.
- **Docker & Docker Compose**: For containerizing the microservice and managing container orchestration.