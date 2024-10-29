# Setting Custom Identity Properties in Marten

In Marten, documents are typically identified using properties named `Id`, `ID`, or `id`. However, there may be cases where an alternative property is more appropriate as the document identifier. Marten supports customizing the identity property through two different approaches:

## 1. Using the `[Identity]` Attribute

### Explanation
The `[Identity]` attribute allows you to designate a different property as the identifier by marking it directly in your document class. This is particularly useful for clearly defining which property serves as the unique identifier in a straightforward manner.

### When to Use
- When the identifier property is non-standard and does not follow the conventional `Id` naming.
- In scenarios where you want to keep the identity configuration close to the document class for clarity and cohesion.

### Example

```csharp
using Marten;

public class NonStandardDoc
{
    [Identity]
    public string Name { get; set; }
}
```

## 2. Configuring Identity with `StoreOptions`

### Explanation
Configuring the identity property through `StoreOptions` involves specifying the identity field in the application's startup configuration. This method is highly flexible and allows for centralized management of identity settings across multiple document types.

### When to Use
- In applications with complex configurations where multiple document types might require different identity properties.
- When you prefer not to modify the document classes directly to maintain a separation between the data access configuration and the domain models.

### Example
```csharp
var storeOptions = new StoreOptions();
storeOptions.Schema.For<OverriddenIdDoc>().Identity(x => x.Name);
```

## Comparison of Approaches

| Feature                               | `[Identity]` Attribute                    | `StoreOptions` Configuration              |
|---------------------------------------|-------------------------------------------|-------------------------------------------|
| **Simplicity**                        | Easier for single-document configuration  | Suitable for centralized configuration    |
| **Configuration Location**            | Within the document class                 | In application setup (e.g., `Startup.cs`) |
| **Flexibility for Multi-documents**   | Limited                                   | Suitable for multi-document configurations|
| **Dependency on Document Class**      | Modifies the document class               | Independent of document class             |

## Conclusion

Both approaches offered by Marten for specifying custom identity properties cater to different needs and scenarios. The `[Identity]` attribute is straightforward and ideal for single-document setups or when simplicity is a priority. On the other hand, the `StoreOptions` configuration offers a more flexible and scalable solution for complex applications with multiple document types, allowing for centralized management of identity properties without altering the domain models directly. This flexibility makes it particularly suited for large-scale projects or those requiring detailed configuration management.
