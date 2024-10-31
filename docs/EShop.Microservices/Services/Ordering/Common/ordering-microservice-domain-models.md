# Domain Models of Ordering Microservices

This document provides an overview of the domain models used in the Ordering Microservice. The primary models include `Order` and `OrderItem`, with considerations for integration events in the ordering process.

---

## Primary Domain Models

### `Order` Model
- Represents an order made by a customer.
- **Attributes**:
  - `CustomerId`: ID linking the order to a specific customer.
  - `OrderName`: Name or identifier for the order.
  - `ShippingAddress`: Address to which the order will be shipped.
  - `BillingAddress`: Address associated with the payment method.
  - `Payment`: Payment details associated with the order.
  - `OrderStatus`: Status of the order (e.g., pending, completed).
  - `OrderItems`: Collection of items within the order, defined by the `OrderItem` model.

### `OrderItem` Model
- Represents an individual item within an `Order`.
- **Relationship**: Each `Order` can contain multiple `OrderItems` (1..N).

---

## Relationships and Events

- **Customer Relationship**:
  - Each `Order` is linked to a `Customer`.
  - A `Customer` can have multiple `Orders` (1..N relationship).

- **Product Relationship**:
  - Each `OrderItem` is associated with a `Product`.
  - A `Product` can belong to multiple `OrderItems` across different orders.

- **Category Relationship**:
  - Each `Product` can belong to a `Category`.
  - A `Category` can contain multiple `Products` (1..N relationship).

### Integration Events

- **OrderCreated Event**:
  - This event is triggered when a new order is created.
  - It can be used to integrate with other services, such as inventory, payment, or notification services.

