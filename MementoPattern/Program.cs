using MementoPattern.UseCases.SimpleExample;
using MementoPattern.UseCases.FormExample;

namespace MementoPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MEMENTO PATTERN DEMONSTRATIONS");
            Console.WriteLine("==============================");

            // Run the simple text example
            SimpleExampleDemo.Run();

            // Run the form example
            FormExampleDemo.Run();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
