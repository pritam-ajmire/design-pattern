using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ObserverPattern.Core.NotificationStrategies;

/// <summary>
/// Parallel notification strategy that notifies observers simultaneously using Parallel.ForEach.
/// </summary>
/// <typeparam name="T">The type of the subject</typeparam>
public class ParallelStrategy<T> : INotificationStrategy<T>
{
    public void NotifyObservers(ICollection<ISubjectObserver<T>> observers, T subject)
    {
        Parallel.ForEach(observers, observer =>
        {
            try
            {
                observer.Update(subject);
            }
            catch (Exception ex)
            {
                // Log the exception but continue notifying other observers
                Console.WriteLine($"Error notifying observer in parallel: {ex.Message}");
            }
        });
    }
}
