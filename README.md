E-Commerce Microservices Demo
=============================

Overview
--------

This project is a demonstration of a modern e-commerce backend system implemented as a set of microservices using **ASP.NET Core 9** and **React** for the frontend. It showcases advanced architectural patterns including:

*   **Domain-Driven Design (DDD)**
    
*   **CQRS (Command Query Responsibility Segregation)**
    
*   **Event-Driven Architecture (EDA) with Domain Events**
    
*   **Outbox Pattern** for reliable event publishing
    
*   **Unit of Work (UoW) Pattern** for transactional consistency
    
*   **Separation of Read and Write Models** with dedicated databases for optimized queries
    
*   **Microservices** architecture with clear bounded contexts for scalability and maintainability
    

Project Structure
-----------------

The backend is structured into several microservices, each responsible for a specific domain:

*   **Product Service** (Read-only product catalog)
    
*   **Cart Service** (Shopping cart management)
    

Each microservice follows a layered architecture pattern:

- **API Layer** (Minimal APIs or Controllers)  
  ↓  
- **Application Layer** (CQRS Handlers, Commands, Queries, Interfaces)  
  ↓  
- **Domain Layer** (Aggregates, Entities, Value Objects, Domain Events, Business Logic)  
  ↓  
- **Infrastructure Layer** (EF Core DbContext, Repository Implementations, Messaging)

Key Patterns and Concepts
-------------------------

### Domain-Driven Design (DDD)

*   Business logic and domain rules are encapsulated within **Aggregates** and **Entities**.
    
*   Rich domain models maintain consistency and enforce invariants.
    
*   **Domain Events** signal important business occurrences.
    

### CQRS (Command Query Responsibility Segregation)

*   Commands handle state-changing operations (e.g., add item to cart, checkout).
    
*   Queries handle data retrieval (e.g., get product details, get cart contents).
    
*   Separate models and databases optimize performance and scalability.
    

### Event-Driven Architecture (EDA)

*   Domain events propagate important state changes.
    
*   Events can trigger asynchronous processing or integration with other services.
    
*   The **Outbox Pattern** is used to reliably publish events alongside data changes.
    

### Unit of Work (UoW)

*   Ensures all database changes and event dispatches are part of a single atomic transaction.
    
*   Helps maintain data consistency across multiple operations.
    

### Separation of Read and Write Databases

*   Write side handles commands and complex business logic.
    
*   Read side uses denormalized data optimized for queries and UI performance.
    

### Microservices Approach

*   Each domain context is an independently deployable service.
    
*   Encourages scalability, clear ownership, and technology flexibility.
    

Example Domain Flows
--------------------

*   User adds products to their cart (with quantity control).
    
*   Cart status flows through **Pending → CheckedOut** .
    
*   Domain events trigger subsequent processing (e.g., order creation, payment).
    
*   UI interacts via REST APIs, querying read databases for fast response.
    

Technologies Used
-----------------

*   **Backend:** ASP.NET Core 9, C#, Entity Framework Core