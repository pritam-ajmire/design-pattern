namespace MementoPattern.UseCases.FormExample
{
    /// <summary>
    /// Represents a form field with an ID, label, and value
    /// </summary>
    public class FormField
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }

        public FormField(string id, string label, string value = "")
        {
            Id = id;
            Label = label;
            Value = value;
        }

        public FormField Clone()
        {
            return new FormField(Id, Label, Value);
        }

        public override string ToString()
        {
            return $"{Label}: {Value}";
        }
    }
}
