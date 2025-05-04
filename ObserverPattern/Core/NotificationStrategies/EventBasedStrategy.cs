using System;
using System.Collections.Generic;

namespace ObserverPattern.Core.NotificationStrategies;

/// <summary>
/// Event-based notification strategy that uses C# events to notify observers.
/// </summary>
/// <typeparam name="T">The type of the subject</typeparam>
public class EventBasedStrategy<T> : INotificationStrategy<T>
{
    // Event for notification
    public event EventHandler<SubjectEventArgs<T>> StateChanged;

    public void NotifyObservers(ICollection<ISubjectObserver<T>> observers, T subject)
    {
        // Raise the event
        OnStateChanged(new SubjectEventArgs<T>(subject));
        
        // We still need to notify observers that don't use the event-based approach
        foreach (var observer in observers)
        {
            if (observer is IEventObserver<T> eventObserver)
            {
                // Event observers are notified through the event, not directly
                continue;
            }
            
            try
            {
                observer.Update(subject);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error notifying observer with event: {ex.Message}");
            }
        }
    }
    
    protected virtual void OnStateChanged(SubjectEventArgs<T> e)
    {
        StateChanged?.Invoke(this, e);
    }
}

/// <summary>
/// Event arguments for subject state changes.
/// </summary>
/// <typeparam name="T">The type of the subject</typeparam>
public class SubjectEventArgs<T> : EventArgs
{
    public T Subject { get; }
    
    public SubjectEventArgs(T subject)
    {
        Subject = subject;
    }
}

/// <summary>
/// Interface for observers that want to use event-based notification.
/// </summary>
/// <typeparam name="T">The type of the subject</typeparam>
public interface IEventObserver<T> : ISubjectObserver<T>
{
    void Subscribe(EventBasedStrategy<T> strategy);
    void Unsubscribe(EventBasedStrategy<T> strategy);
}
