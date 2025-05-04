using System;
using System.Collections.Generic;

namespace ObserverPattern.Core.NotificationStrategies;

/// <summary>
/// Standard sequential notification strategy that notifies observers one by one.
/// </summary>
/// <typeparam name="T">The type of the subject</typeparam>
public class SequentialStrategy<T> : INotificationStrategy<T>
{
    public void NotifyObservers(ICollection<ISubjectObserver<T>> observers, T subject)
    {
        foreach (var observer in observers)
        {
            try
            {
                observer.Update(subject);
            }
            catch (Exception ex)
            {
                // Log the exception but continue notifying other observers
                Console.WriteLine($"Error notifying observer: {ex.Message}");
            }
        }
    }
}
