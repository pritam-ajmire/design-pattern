using MementoPattern.Core;

namespace MementoPattern.UseCases.SimpleExample
{
    /// <summary>
    /// Concrete Originator implementation for text content
    /// </summary>
    public class TextOriginator : IOriginator<TextMemento>
    {
        private string _state;

        public string State
        {
            get => _state;
            set
            {
                _state = value;
                Console.WriteLine($"State changed to: {_state}");
            }
        }

        /// <summary>
        /// Creates a memento containing a snapshot of the current state
        /// </summary>
        public TextMemento SaveState()
        {
            Console.WriteLine($"Saving state: {_state}");
            return new TextMemento(_state);
        }

        /// <summary>
        /// Restores the state from a memento
        /// </summary>
        public void RestoreState(TextMemento memento)
        {
            if (memento == null)
            {
                Console.WriteLine("No state to restore");
                return;
            }

            _state = memento.GetState();
            Console.WriteLine($"State restored to: {_state}");
        }
    }
}
