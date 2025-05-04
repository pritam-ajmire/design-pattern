using MementoPattern.Core;

namespace MementoPattern.UseCases.FormExample
{
    /// <summary>
    /// Memento for storing the state of a form with multiple fields
    /// </summary>
    public class FormMemento : IMemento
    {
        private readonly Dictionary<string, FormField> _formState;
        private readonly DateTime _creationDate;

        public FormMemento(Dictionary<string, FormField> state)
        {
            // Create a deep copy of the form state
            _formState = new Dictionary<string, FormField>();
            foreach (var field in state)
            {
                _formState[field.Key] = field.Value.Clone();
            }
            
            _creationDate = DateTime.Now;
        }

        public Dictionary<string, FormField> GetState()
        {
            return _formState;
        }

        public DateTime GetCreationDate()
        {
            return _creationDate;
        }

        public override string ToString()
        {
            return $"{_creationDate}: Form with {_formState.Count} fields";
        }
    }
}
