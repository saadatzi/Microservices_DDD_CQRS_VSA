# Domain Models of Basket Microservices

## Overview

The domain model for the Basket Microservices primarily revolves around the `ShoppingCart`, `ShoppingCartItem`, and `BasketCheckout` entities. These components are essential for managing the basket functionality, including adding items to a shopping cart and performing a checkout action.

### Primary Domain Models

1. **ShoppingCart**
    - Represents the user's shopping cart, which contains multiple `ShoppingCartItem` entries.
    - Contains attributes:
      - **UserName**: Identifies the user associated with the shopping cart.
      - **Items**: List of items in the shopping cart.
      - **TotalPrice**: Calculates the total price of all items in the cart.
    - Example Code:
      ```csharp
      public class ShoppingCart
      {
          public string UserName { get; set; }
          public List<ShoppingCartItem> Items { get; set; }
          public decimal TotalPrice => Items.Sum(item => item.Price);

          public ShoppingCart(string userName)
          {
              UserName = userName;
          }
      }
      ```

2. **ShoppingCartItem**
    - Represents an individual item within the `ShoppingCart`.
    - Each `ShoppingCart` can contain one or more `ShoppingCartItem` objects, establishing a 1-to-N relationship between `ShoppingCart` and `ShoppingCartItem`.

3. **BasketCheckout Event**
    - A domain event that represents the action of checking out the basket.
    - This event leads to integration with other microservices, potentially triggering workflows such as payment processing, order creation, and inventory adjustment.

### Basket Domain Model Diagram

The following relationships are represented in the domain model:
- **ShoppingCart** contains multiple **ShoppingCartItem** entries.
- The **BasketCheckout Event** is triggered upon checkout, allowing integration with external services for processing.

```plaintext
Basket Domain Model
-------------------
        +-------------------+
        |   Shopping Cart   |
        +-------------------+
               1..N |
                    |
               +--------------------+
               | ShoppingCartItem   |
               +--------------------+