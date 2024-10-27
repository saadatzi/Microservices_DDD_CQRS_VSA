# Project Folder Structure of Catalog Microservice

## Overview
The Catalog Microservice is organized into a well-defined folder structure to maintain modularity, readability, and scalability. Each folder encapsulates a specific functionality or layer within the microservice, allowing for easier management and development.

## Folder Structure

### 1. **Models**
   - Contains data models representing the core entities in the microservice.
   - **Example**: `Product.cs` represents the product entity in the catalog.

### 2. **Features**
   - Each feature has a dedicated subfolder within the `Products` folder.
   - **Purpose**: Encapsulates feature-specific endpoints and handlers for better modularity.
   - **Examples**:
     - **CreateProduct**: Contains `CreateProductEndpoint.cs` and `CreateProductHandler.cs` to handle product creation.
     - **GetProduct**: Contains handlers and endpoints for retrieving products.

### 3. **Data**
   - Contains classes related to data management, including context objects that handle database interactions.
   - **CatalogInitialData.cs**: Manages initial data seeding for the catalog.
   - **Context Objects**: Serve as the bridge between the application and the database, managing CRUD operations.

### 4. **Abstractions**
   - Holds abstract classes and interfaces defining contracts for various components.
   - **Purpose**: Promotes loose coupling by allowing dependency injection of different implementations.

### 5. **Exceptions**
   - Contains custom exception classes tailored to specific error cases within the microservice.
   - **Example**: `ProductNotFoundException.cs` handles cases where a product cannot be found.

### Products Folder
   - The `Products` folder is structured to support a **Vertical Slice Architecture**, where each subfolder represents a distinct feature of the microservice.
   - **Examples of Feature Folders**:
     - **CreateProduct**: Handles product creation with dedicated handler and endpoint files.
     - **DeleteProduct**: Manages product deletion functionality.
     - **GetProducts**: Handles retrieval of all products.
     - **UpdateProduct**: Manages product updates.