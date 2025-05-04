namespace ObserverPattern.Core;

/// <summary>
/// The Subject interface declares methods for managing observers.
/// </summary>
/// <typeparam name="T">The type of the subject</typeparam>
public interface ISubject<T>
{
    /// <summary>
    /// Attach an observer to the subject.
    /// </summary>
    /// <param name="observer">The observer to attach</param>
    void Attach(ISubjectObserver<T> observer);
    
    /// <summary>
    /// Detach an observer from the subject.
    /// </summary>
    /// <param name="observer">The observer to detach</param>
    void Detach(ISubjectObserver<T> observer);
    
    /// <summary>
    /// Notify all observers about an event.
    /// </summary>
    void Notify();
}
