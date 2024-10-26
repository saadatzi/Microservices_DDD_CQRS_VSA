# Todo Service - Minimal API Core for Single Microservice

## Objective
Build a minimal Todo Web API using ASP.NET Core to manage to-do items through CRUD operations.

## Architecture Overview
- **Client**: Communicates with the **Todo Service** backend via HTTP requests.
- **Backend - TODO Service**: An ASP.NET Core Web API that performs CRUD operations on to-do items.
- **Database (DB)**: Stores and retrieves to-do items.

## API Endpoints

| HTTP Method | Endpoint              | Description                | Request Body | Response Body            |
|-------------|-----------------------|----------------------------|--------------|--------------------------|
| **GET**     | `/todoitems`          | Retrieve all to-do items   | None         | Array of to-do items     |
| **GET**     | `/todoitems/complete` | Retrieve completed items   | None         | Array of to-do items     |
| **GET**     | `/todoitems/{id}`     | Retrieve a specific item   | None         | To-do item               |
| **POST**    | `/todoitems`          | Add a new to-do item       | To-do item   | Newly created item       |
| **PUT**     | `/todoitems/{id}`     | Update an existing item    | To-do item   | None                     |
| **DELETE**  | `/todoitems/{id}`     | Delete an item             | None         | None                     |

## API Functionalities
- **GET /todoitems**: Fetch all to-do items.
- **GET /todoitems/complete**: Fetch only completed to-do items.
- **GET /todoitems/{id}**: Retrieve a specific item by its ID.
- **POST /todoitems**: Create a new to-do item. Provide item details in the request body.
- **PUT /todoitems/{id}**: Update an existing item’s details by ID.
- **DELETE /todoitems/{id}**: Remove an item by its ID.

## Usage Example
To add a new to-do item:
```http
POST /todoitems
Content-Type: application/json

{
  "title": "New Task",
  "isComplete": false
}

## Response
{
  "id": 1,
  "title": "New Task",
  "isComplete": false
}