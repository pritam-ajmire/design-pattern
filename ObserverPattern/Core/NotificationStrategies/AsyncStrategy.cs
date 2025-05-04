using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ObserverPattern.Core.NotificationStrategies;

/// <summary>
/// Asynchronous notification strategy that notifies observers using Task.Run.
/// </summary>
/// <typeparam name="T">The type of the subject</typeparam>
public class AsyncStrategy<T> : INotificationStrategy<T>
{
    public void NotifyObservers(ICollection<ISubjectObserver<T>> observers, T subject)
    {
        foreach (var observer in observers)
        {
            Task.Run(() =>
            {
                try
                {
                    observer.Update(subject);
                }
                catch (Exception ex)
                {
                    // Log the exception but continue notifying other observers
                    Console.WriteLine($"Error notifying observer asynchronously: {ex.Message}");
                }
            });
        }
    }
}
