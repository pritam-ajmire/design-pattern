namespace MementoPattern.Core
{
    /// <summary>
    /// Interface for all Memento implementations
    /// </summary>
    public interface IMemento
    {
        // Marker interface for type safety
        DateTime GetCreationDate();
    }
}
