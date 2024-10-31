# Design Principles - SOLID

The SOLID principles are a set of design principles that help create more maintainable, understandable, and flexible software. These principles are foundational in object-oriented design and encourage developers to design software with a focus on scalability and adaptability.

---

## 1. Single Responsibility Principle (SRP)
- **Definition**: Each component or module should be responsible for only one functionality.
- **Explanation**: This principle ensures that a class or module has only one reason to change, which makes the code more maintainable and easier to understand.

---

## 2. Open-Closed Principle (OCP)
- **Definition**: Software entities (classes, modules, functions) should be open for extension but closed for modification.
- **Explanation**: A system should allow functionality to be extended without altering its existing codebase, which helps avoid introducing new bugs. This principle supports the development of systems that can adapt to changing requirements.

---

## 3. Liskov Substitution Principle (LSP)
- **Definition**: Objects of a superclass should be replaceable with objects of a subclass without altering the correctness of the program.
- **Explanation**: Systems should be able to substitute components with others easily, allowing plug-in services that can be swapped as needed without breaking functionality.

---

## 4. Interface Segregation Principle (ISP)
- **Definition**: No code should be forced to depend on methods it does not use.
- **Explanation**: This principle ensures that interfaces are tailored to specific clients, avoiding the bloat that can come with generalized interfaces. Clients should only know about the methods that are of interest to them, leading to more modular and flexible code.

---

## 5. Dependency Inversion Principle (DIP)
- **Definition**: High-level modules should not depend on low-level modules. Both should depend on abstractions.
- **Explanation**: This principle dictates that dependencies should be on abstractions (interfaces), not on concrete classes. This results in a decoupled architecture where high-level logic is separated from low-level details, enhancing the flexibility and reusability of the code.

---

![SOLID Principles](https://medium.com/bgl-tech/what-are-the-solid-design-principles-c61eff33685)