# Memento Pattern

## Intent
The Memento pattern is a behavioral design pattern that lets you save and restore the previous state of an object without revealing the details of its implementation. This pattern provides a way to return an object to a previous state (undo via rollback) without violating encapsulation.

## Problem
Sometimes we need to save the state of an object at a certain point and restore it later. For example, in applications with undo functionality, we need to save the state before making changes so we can revert back if needed.

However, directly accessing and storing an object's internal state would violate encapsulation. Additionally, the object itself shouldn't be responsible for storing its historical states as it would complicate its primary responsibility.

## Solution
The Memento pattern delegates the responsibility of saving and restoring an object's state to a separate object called a "memento".

## Structure
The Memento pattern consists of three key components:

1. **Originator**: The object whose state needs to be saved and restored.
   - Creates a memento containing a snapshot of its current internal state
   - Uses the memento to restore its internal state

2. **Memento**: The object that stores the internal state of the Originator.
   - Only the Originator that created a memento should be allowed to access its state
   - Provides a way to retrieve the saved state

3. **Caretaker**: The object responsible for keeping track of the mementos.
   - Stores mementos but never modifies them
   - Decides when to save the Originator's state and when to restore it

## Implementation Example

Here's a simple implementation of the Memento pattern in Java:

```java
// Memento: Stores the state of the Originator
class EditorMemento {
    private final String content;

    public EditorMemento(String content) {
        this.content = content;
    }

    public String getContent() {
        return content;
    }
}

// Originator: The object whose state we want to save
class TextEditor {
    private String content;

    public void setContent(String content) {
        this.content = content;
    }

    public String getContent() {
        return content;
    }

    // Create a memento with the current state
    public EditorMemento save() {
        return new EditorMemento(content);
    }

    // Restore state from a memento
    public void restore(EditorMemento memento) {
        content = memento.getContent();
    }
}

// Caretaker: Manages saved states
class History {
    private final List<EditorMemento> mementos = new ArrayList<>();

    public void push(EditorMemento memento) {
        mementos.add(memento);
    }

    public EditorMemento pop() {
        if (mementos.isEmpty()) {
            return null;
        }
        EditorMemento lastMemento = mementos.get(mementos.size() - 1);
        mementos.remove(mementos.size() - 1);
        return lastMemento;
    }
}

// Client code
public class MementoDemo {
    public static void main(String[] args) {
        TextEditor editor = new TextEditor();
        History history = new History();

        // Edit and save state
        editor.setContent("First draft");
        history.push(editor.save());

        // Edit again and save state
        editor.setContent("Second draft");
        history.push(editor.save());

        // Edit again
        editor.setContent("Final version");

        // Undo to second draft
        editor.restore(history.pop());
        System.out.println(editor.getContent()); // Output: Second draft

        // Undo to first draft
        editor.restore(history.pop());
        System.out.println(editor.getContent()); // Output: First draft
    }
}
```

## When to Use
- When you need to create snapshots of an object's state to restore it later
- When direct access to an object's fields/getters/setters would expose implementation details and break encapsulation
- When implementing undo/redo functionality
- When implementing transaction rollbacks

## Benefits
1. Preserves encapsulation by not exposing the object's implementation details
2. Simplifies the originator code by letting the caretaker maintain the history of the originator's state
3. Provides a clean way to implement undo/redo functionality

## Drawbacks
1. Can consume a lot of memory if clients create many mementos
2. May require additional care in languages with reference-based objects
3. Caretakers should track the originator's lifecycle to destroy obsolete mementos

## Related Patterns
- **Command Pattern**: Commands can store states for undoing operations using mementos
- **Iterator Pattern**: Mementos can be used to capture and restore an iterator's state
- **Prototype Pattern**: Can be used as an alternative when the object's state is simple and can be easily copied
