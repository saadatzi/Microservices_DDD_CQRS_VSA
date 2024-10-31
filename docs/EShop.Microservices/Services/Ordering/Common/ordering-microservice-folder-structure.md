# Project Folder Structure of Ordering Microservices

The ordering microservice follows a Clean Architecture with the following structure:

- **3 Class Libraries**:
  - `Ordering.Domain`
  - `Ordering.Application`
  - `Ordering.Infrastructure`
- **1 Web API**:
  - `Ordering.API`

## Ordering.Domain
This layer contains the core business logic, including domain models and other key elements that define the business rules.

- **Domain Models**: Key entities include `Order`, `OrderItem`, `Customer`, and `Product`.
- **Value Objects and Events**: Defines value objects, domain events, exceptions, and base entity classes.
  
## Ordering.Application
This layer includes the application logic and is structured to handle various features and functionalities, mainly implementing the CQRS (Command Query Responsibility Segregation) pattern.

- **CQRS Commands and Handlers**: Organized by features to handle commands and queries for different actions.
- **Dependency Injection Configurations**: Contains setup for dependency injection to facilitate clean and manageable code.

## Ordering.Infrastructure
This layer is responsible for data access and infrastructure-specific details, such as database configurations.

- **Database Context and Configurations**: Manages database context for interacting with the database.
- **Migrations and Seeding**: Handles migrations and initial data seeding for setting up the database schema and populating initial data.

## Ordering.API
This layer serves as the entry point of the application, managing API requests and defining endpoint contracts.

- **API Contracts and Endpoint Definitions**: Manages API contracts and endpoint definitions for handling HTTP requests.