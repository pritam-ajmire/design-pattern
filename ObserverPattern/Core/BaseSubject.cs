using System.Collections.Generic;
using ObserverPattern.Core.NotificationStrategies;

namespace ObserverPattern.Core;

/// <summary>
/// Base implementation of the Subject interface that includes common functionality
/// for managing observers and notifications.
/// </summary>
/// <typeparam name="T">The type of the concrete subject</typeparam>
public abstract class BaseSubject<T> : ISubject<T> where T : class
{
    protected readonly ICollection<ISubjectObserver<T>> _observers;
    protected INotificationStrategy<T> _notificationStrategy;

    protected BaseSubject(INotificationStrategy<T> notificationStrategy)
    {
        _observers = new List<ISubjectObserver<T>>();
        _notificationStrategy = notificationStrategy;
    }

    public void Attach(ISubjectObserver<T> observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
    }

    public void Detach(ISubjectObserver<T> observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        _notificationStrategy.NotifyObservers(_observers, this as T);
    }

    /// <summary>
    /// Change the notification strategy at runtime.
    /// </summary>
    /// <param name="strategy">The new notification strategy to use</param>
    public void SetNotificationStrategy(INotificationStrategy<T> strategy)
    {
        _notificationStrategy = strategy;
    }
}
