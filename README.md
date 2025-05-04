# Design Patterns

This repository contains implementations of various design patterns in C#. Each pattern is implemented in its own project with detailed explanations, UML diagrams, and practical examples.

## Available Patterns

### Behavioral Patterns

- [Memento Pattern](./MementoPattern/README.md) - Allows capturing and restoring an object's internal state without violating encapsulation, providing undo/redo functionality.
- [Observer Pattern](./ObserverPattern/README.md)) - Defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.

## Project Structure

Each pattern implementation follows a similar structure:

```
PatternName/
├── Core/                   # Core interfaces and base classes
├── UseCases/               # Practical examples of the pattern
├── README.md               # Detailed explanation with UML diagrams
└── Program.cs              # Demo entry point
```

## Getting Started

To run any of the pattern examples:

```bash
cd PatternName
dotnet run
```

## Pattern Categories

Design patterns are typically categorized into three main groups:

1. **Creational Patterns** - Deal with object creation mechanisms, trying to create objects in a manner suitable to the situation.
   - Factory Method
   - Abstract Factory
   - Builder
   - Prototype
   - Singleton

2. **Structural Patterns** - Deal with object composition or the structure of classes and objects.
   - Adapter
   - Bridge
   - Composite
   - Decorator
   - Facade
   - Flyweight
   - Proxy

3. **Behavioral Patterns** - Deal with communication between objects and the assignment of responsibilities.
   - Chain of Responsibility
   - Command
   - Interpreter
   - Iterator
   - Mediator
   - [Memento](./MementoPattern/README.md)
   - [Observer](./ObserverPattern/README.md))
   - State
   - Strategy
   - Template Method
   - Visitor

## License

This project is licensed under the MIT License - see the LICENSE file for details.
