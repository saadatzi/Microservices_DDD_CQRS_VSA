# Catalog Microservice

## Overview
The **Catalog Microservice** is a standalone microservice designed to manage product catalog data. It follows a **Vertical Slice Architecture** and incorporates **CQRS (Command Query Responsibility Segregation)** principles to separate read and write operations, enhancing scalability and maintainability.

## Architecture
The architecture is organized into multiple layers to facilitate a clean, maintainable codebase:

1. **UI**: Responsible for handling user interactions and displaying catalog data.
2. **Application Layer**: Manages business logic and mediates between the UI and Domain layers.
3. **Domain Layer**: Defines core entities and domain logic for catalog items.
4. **Infrastructure Layer**: Provides access to external resources like databases.
5. **Vertical Slice**: A modular approach allowing each feature to include all necessary layers for its functionality.

### Key Concepts
- **Vertical Slice Architecture**: Each feature is independent, containing all layers needed for its functionality.
- **CQRS**: Separates read and write operations to allow more scalable and optimized data handling.

## Technologies Used
- **ASP.NET Core Minimal APIs**: Used for building fast HTTP APIs with fully functioning REST endpoints and a top-level `Program.cs`.
- **Vertical Slice Architecture**: Implementation with feature folders and single `.cs` files that include different classes for each feature.
- **CQRS with MediatR**: Implements CQRS using the `MediatR` library for handling requests and responses.
- **Marten**: A .NET library for a transactional document DB on PostgreSQL, enabling seamless data management.
- **Carter**: Used for minimal API endpoint definitions, making the API endpoints clean and readable.
- **Mapster**: Utilized for mapping DTO (Data Transfer Object) classes where possible.
- **FluentValidation**: Validates inputs and integrates with `MediatR` for validation in the request pipeline.
- **Docker & Docker Compose**: Contains `Dockerfile` and `docker-compose.yml` for running the Catalog microservice and PostgreSQL database in a containerized environment.

## Underlying Data Structures

The Catalog Microservice uses a **Document Database** structure to store catalog data as JSON, providing flexibility and scalability for managing dynamic catalog data.

- **Database Options**: 
  - MongoDB (No-SQL database)
  - PostgreSQL JSON Columns (chosen option for this microservice) with the **Marten** library.

- **Marten Library**: A powerful library that transforms PostgreSQL into a **.NET Transactional Document DB**, combining the flexibility of document databases with the reliability of relational databases.

- **PostgreSQL's JSON Column Features**: Utilizes PostgreSQL’s ability to store and query JSON documents directly, allowing efficient storage and retrieval of JSON data within a relational framework.

This approach combines the flexibility of a document database with the strong transactional support of a relational PostgreSQL database, making it ideal for complex, dynamic data needs in the catalog.

## Port Configuration

| Microservices | Local Environment | Docker Environment | Docker Internal Ports |
|---------------|-------------------|--------------------|-----------------------|
| **Catalog**   | 5000 – 5050       | 6000 – 6060       | 8080 – 8081          |
| **Basket**    | 5001 – 5051       | 6001 – 6061       | 8080 – 8081          |
| **Discount**  | 5002 – 5052       | 6002 – 6062       | 8080 – 8081          |
| **Ordering**  | 5003 – 5053       | 6003 – 6063       | 8080 – 8081          |

> **Note**: ASP.NET Core ports are listed as `http`/`https` for running applications.

## Components
- **Catalog.API Container**: The containerized microservice that hosts the Catalog API, handling HTTP requests for catalog operations.
- **Catalog DB**: A PostgreSQL database used for persistent storage of catalog data.

## Deployment
### External Access
- **External IP and Port**: Allows clients to access the Catalog API over the network.

### Internal Communication
- **Internal IP and Port**: Enables the Catalog API to communicate with internal services and the Catalog Database.

## Getting Started

### Prerequisites
- **Docker**: Make sure Docker is installed and running on your system.
- **.NET 8 SDK**: Required to build and run the application locally.

### Running the Catalog Microservice
1. **Build the Docker Image**:
   ```bash
   docker build -t catalog-api .
