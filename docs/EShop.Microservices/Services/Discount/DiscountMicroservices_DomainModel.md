# Domain Models of Discount Microservices

## 1. Primary Domain Model: `Coupon`

The primary domain model for the Discount Microservice is the `Coupon` class. This class defines the key properties that represent a discount coupon in the system. Below is a breakdown of its properties and purpose.

### Code Structure

```csharp
public class Coupon
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public int Amount { get; set; }
}
```

## Properties
- **Id**: An integer that uniquely identifies each coupon.
- **ProductName**: A string representing the name of the product that the coupon applies to.
- **Description**: A string that provides additional details about the coupon.
- **Amount**: An integer indicating the discount amount or value associated with the coupon.

## Diagram
In the Discount Microservices Domain Model, the Coupon class encapsulates the details required to handle discount logic. This model serves as a central part of the discount functionality, enabling various operations like retrieving discount details based on the product, calculating discounts, and managing coupon data.

## Summary
The Coupon domain model is fundamental for discount operations within the Discount Microservice. It represents essential attributes such as the coupon identifier, product name, description, and discount amount, which are required for processing and applying discounts in the system.