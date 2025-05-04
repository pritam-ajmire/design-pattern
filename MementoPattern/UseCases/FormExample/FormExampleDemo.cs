using MementoPattern.Core;

namespace MementoPattern.UseCases.FormExample
{
    /// <summary>
    /// Demonstrates the form example of the Memento pattern
    /// </summary>
    public class FormExampleDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== FORM EXAMPLE ===\n");
            
            // Create form originator and caretaker
            var form = new FormOriginator();
            var caretaker = new Caretaker<FormOriginator, FormMemento>(form);

            // Initialize form with fields
            form.InitializeForm(new List<FormField>
            {
                new FormField("name", "Full Name"),
                new FormField("email", "Email Address"),
                new FormField("phone", "Phone Number"),
                new FormField("address", "Home Address")
            });

            // Save initial empty state
            caretaker.Backup();

            // Fill out form fields sequentially
            Console.WriteLine("\nFilling out form fields sequentially:");
            
            // Step 1: Fill name
            form.UpdateField("name", "John Doe");
            caretaker.Backup();
            
            // Step 2: Fill email
            form.UpdateField("email", "john.doe@example.com");
            caretaker.Backup();
            
            // Step 3: Fill phone
            form.UpdateField("phone", "555-123-4567");
            caretaker.Backup();
            
            // Step 4: Fill address
            form.UpdateField("address", "123 Main St, Anytown, USA");
            caretaker.Backup();

            // Display current form state
            Console.WriteLine("\nFinal form state:");
            form.DisplayCurrentState();

            // Show history
            Console.WriteLine("\nForm state history:");
            caretaker.ShowHistory();

            // Demonstrate undo functionality
            Console.WriteLine("\nUndoing last change (address):");
            caretaker.Undo();

            Console.WriteLine("\nUndoing another change (phone):");
            caretaker.Undo();

            // Demonstrate redo functionality
            Console.WriteLine("\nRedoing a change (adding phone back):");
            caretaker.Redo();

            // Show final state
            Console.WriteLine("\nFinal form state after undo/redo operations:");
            form.DisplayCurrentState();
        }
    }
}
