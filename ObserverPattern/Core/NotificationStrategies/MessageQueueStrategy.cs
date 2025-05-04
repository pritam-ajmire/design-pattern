using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ObserverPattern.Core.NotificationStrategies;

/// <summary>
/// Message queue-based notification strategy that uses a background worker to process notifications.
/// </summary>
/// <typeparam name="T">The type of the subject</typeparam>
public class MessageQueueStrategy<T> : INotificationStrategy<T>, IDisposable
{
    private readonly ConcurrentQueue<NotificationMessage<T>> _messageQueue;
    private readonly CancellationTokenSource _cancellationTokenSource;
    private readonly Task _processingTask;
    private bool _disposed;

    public MessageQueueStrategy()
    {
        _messageQueue = new ConcurrentQueue<NotificationMessage<T>>();
        _cancellationTokenSource = new CancellationTokenSource();
        _processingTask = Task.Run(ProcessQueueAsync, _cancellationTokenSource.Token);
    }

    public void NotifyObservers(ICollection<ISubjectObserver<T>> observers, T subject)
    {
        // Enqueue a notification message for each observer
        foreach (var observer in observers)
        {
            _messageQueue.Enqueue(new NotificationMessage<T>(observer, subject));
        }
    }

    private async Task ProcessQueueAsync()
    {
        while (!_cancellationTokenSource.Token.IsCancellationRequested)
        {
            // Process all messages in the queue
            while (_messageQueue.TryDequeue(out var message))
            {
                try
                {
                    message.Observer.Update(message.Subject);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing message queue notification: {ex.Message}");
                }
            }

            // Wait a bit before checking the queue again
            await Task.Delay(10, _cancellationTokenSource.Token);
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {
            _cancellationTokenSource.Cancel();
            try
            {
                _processingTask.Wait(1000); // Give the task a chance to complete
            }
            catch (AggregateException)
            {
                // Task was canceled, which is expected
            }
            _cancellationTokenSource.Dispose();
        }

        _disposed = true;
    }

    ~MessageQueueStrategy()
    {
        Dispose(false);
    }
}

/// <summary>
/// Represents a notification message in the queue.
/// </summary>
/// <typeparam name="T">The type of the subject</typeparam>
public class NotificationMessage<T>
{
    public ISubjectObserver<T> Observer { get; }
    public T Subject { get; }

    public NotificationMessage(ISubjectObserver<T> observer, T subject)
    {
        Observer = observer;
        Subject = subject;
    }
}
