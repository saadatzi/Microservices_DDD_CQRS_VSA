# Underlying Data Structures of Basket Microservices

Basket Microservices has 2 Data Stores:

1. **Marten Document Database**
2. **Redis Distributed Cache**

## Marten

Marten is a powerful library that transforms **PostgreSQL** into a **.NET Transactional Document DB** using PostgreSQL's JSON column features.

## Redis

Redis is a powerful in-memory data store and distributed cache which is a good fit for microservices architectures.

## Summary

- **Marten** allows for flexible data modeling and transactional support using the underlying PostgreSQL database.
- **Redis** provides high-speed data access and is effective for caching and temporary data storage in microservices, improving application performance.