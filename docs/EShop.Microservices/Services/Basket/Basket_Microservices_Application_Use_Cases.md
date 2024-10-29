# Application Use Cases of Basket Microservices

## 1. CRUD Basket Operations

The following operations define the core functionalities of the Basket Microservices related to managing the shopping cart:

- **Get ShoppingCart with Items**
  - Retrieves the current user's shopping cart along with its items.

- **Store (Upsert - Create and Update) ShoppingCart with Items**
  - This operation includes several actions:
    - **Add Item into ShoppingCart**: Allows the addition of new items to the user's cart.
    - **Remove Item from ShoppingCart**: Facilitates the removal of items from the user's cart.
    - **Update ShoppingCartItem in ShoppingCart**: Increases the quantity of existing items in the cart.

- **Delete ShoppingCart with Items**
  - Deletes the shopping cart along with all the items it contains.

## 2. gRPC Basket Operations

- **When Store Basket**: This operation is designed to:
  - **GetDiscount**: Retrieve any available discounts applicable to the user's basket.
  - **Deduct discount coupon from Item Price**: Apply the discount to the total price of the items in the basket.

## 3. Async Basket Operations

- **Checkout Basket**: 
  - Publish an event to RabbitMQ Message Broker to process the checkout action asynchronously.
  
  This allows for decoupling the checkout process from the main application flow, enabling better scalability and responsiveness.

## Conclusion

These use cases provide a comprehensive view of how Basket Microservices function within an application, enabling efficient management of shopping carts, discounts, and checkout processes.