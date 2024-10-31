# Clean Architecture Layers

Clean Architecture divides the system into layers to promote separation of concerns, maintainability, and scalability. Each layer has distinct responsibilities, ensuring that changes in one layer do not heavily impact the others. Below is a breakdown of the primary layers in Clean Architecture.

---

## Entities Layer (Domain Layer)
- **Purpose**: Contains enterprise-wide business rules.
- **Role**: The Entities Layer encapsulates the most general and high-level rules, focusing on the core business domain. It serves as the foundation of the application, holding the business rules that should be applicable across different applications within the enterprise.
- **Example**: In an ordering microservice, entities might include:
  - **Order**
  - **OrderItem**
  - **Customer**
  - **Product**

---

## Use Cases Layer (Application Layer)
- **Purpose**: Contains application-specific business rules.
- **Role**: This layer encapsulates and implements all use cases of the system, representing specific application logic and behaviors. It handles the interactions and workflows between entities based on the requirements, ensuring the correct flow and enforcement of business rules.
- **Example Use Cases**:
  - **CreateOrder**: Logic to create a new order.
  - **CancelOrder**: Logic to cancel an existing order.
  - **UpdateOrderStatus**: Logic to update the status of an order (e.g., processing, shipped, completed).

---

## Interface Adapters Layer (Infrastructure Layer)
- **Purpose**: Converts data between the format most convenient for the use cases and entities and the format most convenient for external systems.
- **Role**: This layer acts as a bridge between the application core and the external systems. It ensures that data flows correctly between different parts of the system.
- **Example**: Mapping data from database models to domain entities, handling transformations that are necessary for the data to be usable by the core logic.

---

## Frameworks and Drivers Layer (Infrastructure/External Concerns)
- **Purpose**: The outermost layer, consisting of frameworks and tools such as databases, web frameworks, etc.
- **Role**: This layer includes any external interface, like REST controllers and database repositories, which allow interaction with the system.
- **Example**: REST controllers that expose API endpoints, database repositories for data persistence.

---

## Diagrams

- **Core and Periphery**: 
  - The **Core** layers (Domain and Application) contain the core business logic, which remains insulated from external changes.
  - The **Periphery** layers (Infrastructure and Presentation) interact with external elements like databases and user interfaces but do not impact the core business rules.

- **Layered Structure**: 
  - The diagram illustrates how each layer operates independently, allowing changes to external interfaces without affecting the core business logic. This structure supports clean separation between domain-specific rules, use cases, and external implementations.
