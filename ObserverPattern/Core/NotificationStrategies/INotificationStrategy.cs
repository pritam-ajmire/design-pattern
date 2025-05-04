using System.Collections.Generic;

namespace ObserverPattern.Core.NotificationStrategies;

/// <summary>
/// Interface for notification strategies that define how observers are notified.
/// </summary>
/// <typeparam name="T">The type of the subject</typeparam>
public interface INotificationStrategy<T>
{
    /// <summary>
    /// Notify all observers about an event.
    /// </summary>
    /// <param name="observers">Collection of observers to notify</param>
    /// <param name="subject">The subject that triggered the notification</param>
    void NotifyObservers(ICollection<ISubjectObserver<T>> observers, T subject);
}
