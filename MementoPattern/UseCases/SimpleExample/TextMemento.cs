using MementoPattern.Core;

namespace MementoPattern.UseCases.SimpleExample
{
    /// <summary>
    /// Concrete Memento implementation for storing text state
    /// </summary>
    public class TextMemento : IMemento
    {
        private readonly string _state;
        private readonly DateTime _creationDate;

        public TextMemento(string state)
        {
            _state = state;
            _creationDate = DateTime.Now;
        }

        // Only accessible to the originator
        public string GetState()
        {
            return _state;
        }

        public DateTime GetCreationDate()
        {
            return _creationDate;
        }

        public override string ToString()
        {
            return $"{_creationDate}: {_state}";
        }
    }
}
