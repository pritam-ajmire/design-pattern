using MementoPattern.Core;

namespace MementoPattern.UseCases.FormExample
{
    /// <summary>
    /// Originator for a form with multiple fields
    /// </summary>
    public class FormOriginator : IOriginator<FormMemento>
    {
        private Dictionary<string, FormField> _formFields = new Dictionary<string, FormField>();

        // Initialize the form with fields
        public void InitializeForm(List<FormField> fields)
        {
            _formFields.Clear();
            foreach (var field in fields)
            {
                _formFields[field.Id] = field;
            }
            Console.WriteLine("Form initialized with fields: " + string.Join(", ", _formFields.Values.Select(f => f.Label)));
        }

        // Update a single field
        public void UpdateField(string fieldId, string value)
        {
            if (_formFields.TryGetValue(fieldId, out var field))
            {
                field.Value = value;
                Console.WriteLine($"Field '{field.Label}' updated to: {value}");
            }
            else
            {
                Console.WriteLine($"Field with ID '{fieldId}' not found");
            }
        }

        // Get current value of a field
        public string GetFieldValue(string fieldId)
        {
            return _formFields.TryGetValue(fieldId, out var field) ? field.Value : string.Empty;
        }

        // Get all form fields
        public IReadOnlyDictionary<string, FormField> GetFormFields()
        {
            return _formFields;
        }

        // Save the current state of all form fields
        public FormMemento SaveState()
        {
            Console.WriteLine("Saving form state...");
            return new FormMemento(_formFields);
        }

        // Restore a previous state
        public void RestoreState(FormMemento memento)
        {
            _formFields = new Dictionary<string, FormField>();
            foreach (var field in memento.GetState())
            {
                _formFields[field.Key] = field.Value.Clone();
            }
            
            Console.WriteLine("Form state restored");
            DisplayCurrentState();
        }

        // Display the current state of the form
        public void DisplayCurrentState()
        {
            Console.WriteLine("Current Form State:");
            foreach (var field in _formFields.Values)
            {
                Console.WriteLine($"  {field}");
            }
        }
    }
}
