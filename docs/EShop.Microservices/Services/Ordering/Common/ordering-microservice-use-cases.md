# Application Use Cases of Ordering Microservices

This document outlines the primary use cases for the Ordering Microservices, divided into CRUD operations and asynchronous operations to handle different aspects of the order lifecycle.

---

## CRUD Ordering Operations

The following CRUD operations allow for managing orders and their associated items:

- **Get Order with Items**: Retrieve an order along with its items. Supports filtering by `Name` and `Customer`.
- **Create a New Order**: Add a new order record.
- **Update an Existing Order**: Modify an existing order.
- **Delete Order**: Remove an order from the system.
- **Add and Remove Item from Order**: Manage individual items within an order by adding or removing them as needed.

---

## Asynchronous Ordering Operations

Certain operations are handled asynchronously to improve system efficiency and integrate with other services:

- **Basket Checkout**:
  - Consumes `Basket Checkout` events from RabbitMQ using MassTransit.
  - Ensures a seamless checkout process by coordinating with other services.

- **Order Fulfillment**:
  - Executes order fulfillment tasks such as billing, shipment, and notifications.
  - Supports a streamlined approach to completing an order post-checkout.

- **Raise `OrderCreated` Domain Event**:
  - Triggers an integration event when an order is created.
  - Allows other services to react to the creation of a new order, enabling further processing or notifications.
