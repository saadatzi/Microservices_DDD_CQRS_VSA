# Application Architecture Style of Discount Microservices

## Traditional N-Layer Architecture

The Discount Microservices follow a traditional N-layer architecture model, which separates concerns into distinct layers to improve modularity and maintainability.

### 1. Data Access Layer
- **Purpose**: Handles all database operations.
- **Tasks**: Responsible for adding, deleting, updating, and extracting data from the database.
- **Details**: This layer is solely focused on data management, ensuring the application maintains a separation of concerns by not directly accessing data within other layers.

### 2. Business Layer
- **Purpose**: Implements the business logic.
- **Function**: Processes data provided by the Data Access layer and applies business rules or transformations.
- **Note**: In this architecture, the Data Access layer is not accessed directly by other layers, ensuring data manipulation is consistently handled through the Business layer.

### 3. Presentation Layer
- **Purpose**: User interaction and data display.
- **Role**: Presents data to the user and transmits data from the user to the Business Layer and Data Access layer.
- **Details**: This layer is the front-end component, handling user interfaces and communication with the underlying layers to facilitate seamless data flow.


## Patterns & Principles of Discount Microservices

1. **gRPC ProtoBuf Files Endpoints**: Used for efficient service communication between microservices.
2. **Entity Framework Core**: An ORM (Object-Relational Mapping) tool for managing database operations in a structured and efficient manner.
3. **SQLite Database**: An embedded SQL database that provides a lightweight and efficient storage solution, suitable for small-scale data like discounts.