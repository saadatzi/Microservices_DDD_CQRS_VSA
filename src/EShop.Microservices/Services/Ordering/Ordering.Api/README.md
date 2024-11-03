# REST API Endpoints of Ordering Microservices

## API Endpoints Table

| Method | Request URI                             | Use Cases                      |
|--------|-----------------------------------------|--------------------------------|
| GET    | `/orders`                               | Get Orders with Pagination     |
| GET    | `/orders/{orderName}`                   | Get Orders by OrderName        |
| GET    | `/orders/customer/{customerId}`         | Get Orders by Customer         |
| POST   | `/orders`                               | Create a New Order             |
| PUT    | `/orders`                               | Update an Existing Order       |
| DELETE | `/order/{id}`                           | Delete Order with Id           |

## Notes
- **AMQP**: This API setup includes consuming the **BasketCheckout Event** from **RabbitMQ** using **MassTransit** for asynchronous messaging.
