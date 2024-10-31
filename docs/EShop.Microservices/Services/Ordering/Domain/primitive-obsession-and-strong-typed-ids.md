```markdown
# Primitive Obsession

## Definition
- **Primitive Obsession** is a **code smell** where primitives (like `string`, `int`, `Guid`) are used for domain-specific concepts. This can lead to **ambiguity** and **errors** because primitive types lack the context that custom types can provide.

## Problem with Primitive Obsession
- Using a `Guid` or `string` for identifiers such as `orderId`, `customerId`, or `productId` makes it easy to **mix up identifiers**, as they all share the same data type but represent different domain concepts.
- This can cause **confusion and bugs** in the system, as there's no inherent type safety to prevent using one identifier in place of another.

## Example of Primitive Obsession

```csharp
public class CheckingAccount
{
    public int AccountNumber { get; set; }
    public string CustomerName { get; set; }
    public string Email { get; private set; }
    public string Address { get; set; }
    public int ZipCode { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string SocialSecurityNumber { get; set; }
    public DateTime ActiveDate { get; set; }
    public string GetSSNLast4Digit() { /* ... */ }
}
```

### Issues in the Example
- The `CheckingAccount` class uses **multiple `string` and `int` fields** to represent different domain-specific values such as `AccountNumber`, `ZipCode`, `SocialSecurityNumber`, and `Email`.
- There is a **lack of distinction** between these fields since they are all primitive types, making it easy to accidentally interchange them.
- Additionally, this approach **fails to encapsulate** behaviors or validation rules specific to each domain concept (e.g., validating `SocialSecurityNumber` format, ensuring `ZipCode` matches the country's format).

---

# Strong Typed IDs Pattern

## Definition
- Creating **distinct types** for each kind of ID in your domain, often referred to as the **Strong Typed IDs Pattern**.
- This makes code **more expressive** and **less error-prone**, as each type of ID has a specific class or struct representing it.

## Benefits
- **Clarifies which type of ID is expected**, reducing the risk of mixing IDs (e.g., accidentally using `productId` where `orderId` is intended).
- Enforces **type safety** by defining custom types, preventing misuse of identifiers and enhancing readability.

## Refactored Example with Strong Typed IDs

Using strong typed IDs involves encapsulating related fields as **value objects** with specific types, as shown below:

```csharp
public class CheckingAccount
{
    public int AccountNumber { get; set; }
    public string CustomerName { get; set; }
    public string Email { get; private set; }
    public Address Address { get; set; }
    public DateTime ActiveDate { get; set; }
    public SocialSecurity SocialSecurity { get; set; }
}
```

In this example:
- `Address` and `SocialSecurity` are **custom types** representing domain-specific concepts, encapsulating behaviors and validation directly within the type.
- This improves **clarity** and **safety** by ensuring the correct type of information is assigned to each property.

## Additional Benefits of Strong Typed IDs
- Adds **type safety** to prevent mixing different domain-specific concepts.
- Encapsulates **validation rules** and **business logic** directly within the type, making the code more maintainable.
- Improves **code readability** and **clarity** by clearly distinguishing different concepts through type names.