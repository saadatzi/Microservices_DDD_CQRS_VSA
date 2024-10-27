# Eshop Microservices: Catalog vs Ordering

## Overview
The Eshop application comprises multiple microservices, each responsible for specific domains within the e-commerce platform. This document compares two primary microservices—**Catalog** and **Ordering**—highlighting their architecture, deployment, and data storage solutions.

---

## Microservice Breakdown

### 1. Catalog Microservice
- **Purpose**: Manages product catalog data, including product information, categories, and inventory.
- **Architecture**: Follows **Vertical Slice Architecture**.
  - **UI Layer**: API endpoints for catalog operations.
  - **Application Layer**: Business logic for catalog functionality.
  - **Domain Layer**: Core entities and domain rules (e.g., `Product`).
  - **Infrastructure Layer**: Database access and integrations.
- **Deployment**:
  - Runs in a **Docker container** (`Catalog.API Container`).
  - Accessible via **Internal IP and Port** on the Docker host.
- **Database**:
  - Uses **PostgreSQL** with **Marten** to leverage JSON support, transforming PostgreSQL into a document-oriented database suited for flexible product data.

### 2. Ordering Microservice
- **Purpose**: Handles order processing, including creation, updates, and tracking.
- **Architecture**: Implements **Clean Architecture**.
  - **Controllers**: HTTP entry points for order processing.
  - **Use Cases**: Encapsulates business rules specific to orders.
  - **Entities**: Core business models like `Order`.
  - **Interfaces**: Abstractions for dependency management.
  - **Frameworks & Drivers**: Infrastructure components (e.g., repositories).
- **Deployment**:
  - Runs in a **Docker container** (`Ordering Container`).
  - Also accessible through **Internal IP and Port** on the Docker host.
- **Database**:
  - Uses **SQL Server**, providing strong support for relational data and transactional consistency with ORM integration.

---

## Architectural Patterns

### Catalog Microservice: Vertical Slice Architecture
- **Approach**: Organizes the service by features, each "slice" containing its own UI, Application, Domain, and Infrastructure layers.
- **Advantages**:
  - Simplifies scaling and modifying specific features independently.
  - Improves modularity by focusing on feature-based organization.

### Ordering Microservice: Clean Architecture
- **Approach**: Separates business logic from dependencies, ensuring core functionality remains independent of external frameworks.
- **Advantages**:
  - Enhances testability by isolating core logic from infrastructure.
  - Facilitates flexibility, allowing infrastructure components (e.g., database) to be replaced without affecting business rules.

---

## Key Differences

| Aspect                | Catalog Microservice                    | Ordering Microservice             |
|-----------------------|-----------------------------------------|-----------------------------------|
| **Architecture**      | Vertical Slice Architecture             | Clean Architecture                |
| **Database**          | PostgreSQL (with JSON via Marten)       | SQL Server                        |
| **Purpose**           | Product catalog management              | Order processing                  |
| **Container**         | `Catalog.API Container`                 | `Ordering Container`              |
| **Data Model**        | Document-oriented (JSON)                | Relational (SQL)                  |
| **Layering Approach** | Organized by feature (Vertical Slice)   | Layered around business rules (Clean) |

---

## Deployment Overview

Both microservices are containerized using Docker, enabling consistent deployment and scalability. Each container is accessible through internal IPs and ports, with external configurations available for client or inter-service access.

### Catalog Microservice Deployment
- **Container**: Runs in Docker with PostgreSQL as the database.
- **Data Handling**: Uses Marten for managing JSON documents in PostgreSQL, enabling flexible data storage for the catalog.

### Ordering Microservice Deployment
- **Container**: Runs in Docker with SQL Server as the database.
- **Data Handling**: Uses an ORM for object-relational mapping, supporting complex relational queries and transactional operations.

---

## Summary

The **Catalog** and **Ordering** microservices utilize distinct architectural patterns suited to their specific roles:
- **Catalog Microservice**: Emphasizes feature-based modularity with Vertical Slice Architecture and document-oriented data storage, optimized for dynamic catalog data.
- **Ordering Microservice**: Uses Clean Architecture for clear separation of business logic and infrastructure, coupled with relational data storage for robust order management.

This approach allows both microservices to evolve independently and supports seamless deployment and scaling through containerization.
