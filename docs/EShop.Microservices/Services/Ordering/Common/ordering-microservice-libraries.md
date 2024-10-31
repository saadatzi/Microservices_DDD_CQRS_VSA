## 3. Libraries NuGet Packages of Ordering Microservices

This section outlines the various libraries and NuGet packages used in different layers of the ordering microservices.

### Domain Layer Libraries
- **No Library**: The domain layer does not depend on any external libraries, adhering to a clean, independent architecture.

### Infrastructure Data Libraries
- **Entity Framework Core**: Used for data access and ORM capabilities, including support for SQL Server and related design tools.

### Application Use Case (UC) Layer Libraries
- **BuildingBlocks Libraries**: Includes reusable libraries such as MediatR for CQRS pattern and FluentValidation for validation.
- **Mapster**: A lightweight object mapping library, used for mapping between different object models efficiently.

### Presentation API Layer Libraries
- **ASP.NET Core Libraries**: Provides necessary features for creating API endpoints and handling HTTP requests.
- **Carter**: A library that simplifies the definition of minimal APIs in ASP.NET Core, making it easier to define clean and concise endpoints.
