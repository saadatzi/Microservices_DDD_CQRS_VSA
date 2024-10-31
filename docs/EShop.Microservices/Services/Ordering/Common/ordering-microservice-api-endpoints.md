# REST API Endpoints of Ordering Microservices

This document outlines the REST API endpoints for the Ordering Microservices, providing details on each endpoint's purpose and usage.

---

## API Endpoints

| Method | Request URI                                | Use Cases                          |
|--------|--------------------------------------------|------------------------------------|
| GET    | `/orders`                                  | Retrieve orders with pagination    |
| GET    | `/orders/{orderName}`                      | Retrieve orders by `OrderName`     |
| GET    | `/orders/customer/{customerId}`            | Retrieve orders by `CustomerId`    |
| POST   | `/orders`                                  | Create a new order                 |
| PUT    | `/orders`                                  | Update an existing order           |
| DELETE | `/order/{id}`                              | Delete an order by `Id`            |

---

## Additional Information

- **AMQP Integration**: This service consumes the `BasketCheckout` event from RabbitMQ using MassTransit for asynchronous messaging, supporting real-time order processing triggered by checkout actions.
