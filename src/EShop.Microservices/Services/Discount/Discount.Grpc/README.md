# REST API Endpoints of Discount Microservices

This document outlines the gRPC methods used in the Discount Microservices, along with their corresponding request URIs and use cases.

| Method (gRPC)      | Request URI              | Use Cases                        |
|--------------------|--------------------------|----------------------------------|
| **GetDiscount**    | `GetDiscountRequest`     | Retrieve discount by product name |
| **CreateDiscount** | `CreateDiscountRequest`  | Create a new discount entry      |
| **UpdateDiscount** | `UpdateDiscountRequest`  | Update an existing discount      |
| **DeleteDiscount** | `DeleteDiscountRequest`  | Delete a discount                |

Each method in this microservice corresponds to a specific discount-related operation. These endpoints help manage discount data, making it possible to create, retrieve, update, or delete discount information.