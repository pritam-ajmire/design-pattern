using MementoPattern.Core;

namespace MementoPattern.UseCases.SimpleExample
{
    /// <summary>
    /// Demonstrates the simple text example of the Memento pattern
    /// </summary>
    public class SimpleExampleDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== SIMPLE TEXT EXAMPLE ===\n");
            
            // Create originator and set initial state
            var originator = new TextOriginator();
            var caretaker = new Caretaker<TextOriginator, TextMemento>(originator);

            // Change state and save
            originator.State = "State #1";
            caretaker.Backup();

            // Change state and save
            originator.State = "State #2";
            caretaker.Backup();

            // Change state again
            originator.State = "State #3";
            caretaker.Backup();

            // Show history of saved states
            Console.WriteLine("\nCurrent saved states:");
            caretaker.ShowHistory();

            // Demonstrate undo functionality
            Console.WriteLine("\nClient: Now, let's rollback!");
            caretaker.Undo();

            Console.WriteLine("\nClient: Once more!");
            caretaker.Undo();

            Console.WriteLine("\nClient: Let's redo!");
            caretaker.Redo();

            Console.WriteLine("\nFinal state history:");
            caretaker.ShowHistory();
        }
    }
}
