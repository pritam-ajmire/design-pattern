namespace ObserverPattern.Core;

/// <summary>
/// The Observer interface declares the update method, used by subjects
/// to notify observers of any changes.
/// </summary>
/// <typeparam name="T">The type of the subject being observed</typeparam>
public interface ISubjectObserver<T>
{
    /// <summary>
    /// Receive update from subject
    /// </summary>
    /// <param name="subject">The subject that triggered the update</param>
    void Update(T subject);
}
