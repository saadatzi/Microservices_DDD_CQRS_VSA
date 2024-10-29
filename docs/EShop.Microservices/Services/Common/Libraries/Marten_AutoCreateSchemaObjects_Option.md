# `AutoCreateSchemaObjects` Options in Marten

Marten provides several options for `AutoCreateSchemaObjects` to control the degree of automation in database schema management:

- **None**: No automatic schema creation or updates. Marten assumes that the schema is fully managed externally.
- **CreateOnly**: Only creates missing schema objects but will not update existing ones. Useful for initial schema setup without modifying existing structures.
- **Update**: Creates new schema objects and makes necessary modifications to existing ones if changes are detected.
- **All**: Full automation that includes creating, updating, and managing schema objects based on document model changes. Best for rapid development and prototyping.

## When to Use `AutoCreateSchemaObjects`

- **Development Environments**: Ideal for development setups where schema changes are frequent, and you need to keep the database schema synchronized with the evolving document model.
- **Prototyping**: Allows for quick iteration and testing without the need for manual schema migration.
- **Testing**: Useful in integration testing environments where the schema needs to be reset or updated frequently.

## Caution for Production Use

While `AutoCreateSchemaObjects` is very convenient for development and testing, it is typically not recommended for production environments. Automated schema changes in production can lead to unexpected database modifications, potentially affecting data integrity and application stability. In production, it's safer to use migration tools or manually manage schema updates.

## Usage Example

To enable `AutoCreateSchemaObjects`, configure it within the `StoreOptions` in your application setup. Here’s an example:

```csharp
var storeOptions = new StoreOptions();
storeOptions.AutoCreateSchemaObjects = AutoCreate.All;
```

## Conclusion

The `AutoCreateSchemaObjects` option in Marten is a powerful tool for managing database schema changes automatically. By providing several levels of control, Marten allows developers to choose the most appropriate level of automation based on their environment and needs. For development and testing, it simplifies schema management, but caution should be exercised in production environments where manual schema management is generally preferred for stability and control.
