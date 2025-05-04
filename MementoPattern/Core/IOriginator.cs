namespace MementoPattern.Core
{
    /// <summary>
    /// Interface for all Originator implementations
    /// </summary>
    public interface IOriginator<T> where T : IMemento
    {
        T SaveState();
        void RestoreState(T memento);
    }
}
