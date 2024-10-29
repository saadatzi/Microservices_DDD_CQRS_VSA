# REST API Endpoints of Basket Microservices

The following table outlines the available REST API endpoints for the Basket Microservices, including the HTTP method, request URI, and associated use cases.

| Method | Request URI           | Use Cases                          |
|--------|-----------------------|------------------------------------|
| GET    | `/basket/{userName}`  | Get basket with username           |
| POST   | `/basket/{userName}`  | Store basket (insert-update)      |
| DELETE | `/basket/{userName}`  | Delete basket with username        |
| POST   | `/basket/checkout`    | Checkout basket                    |

## Summary

- **GET**: Retrieve a user's shopping basket based on the provided username.
- **POST**: Insert or update a user's shopping basket with the given username.
- **DELETE**: Remove a user's shopping basket using their username.
- **POST**: Handle the checkout process for the user's shopping basket.

This structure provides a clear overview of the API functionalities and how they interact with the basket management system.