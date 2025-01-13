using System.Collections.Concurrent;

namespace Flowbite.Blazor.Utilities;

/// <summary>
/// The DebounceTask dispatcher delays the invocation of an action until a predetermined interval has elapsed since the last call.
/// This ensures that the action is only invoked once after the calls have stopped for the specified duration.
/// </summary>
public class Debounce : IDisposable
{
    private readonly System.Timers.Timer _timer = new();
    private bool _disposed;
    private TaskCompletionSource? _taskCompletionSource;

    /// <summary>
    /// Gets a value indicating whether the DebounceTask dispatcher is busy.
    /// </summary>
    public bool Busy => _taskCompletionSource?.Task.Status == TaskStatus.Running && !_disposed;

    /// <summary>
    /// Gets the current task.
    /// </summary>
    public Task CurrentTask => _taskCompletionSource?.Task ?? Task.CompletedTask;

    /// <summary>
    /// Releases all resources used by the DebounceTask dispatcher.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Delays the invocation of an action until a predetermined interval has elapsed since the last call.
    /// </summary>
    /// <param name="milliseconds"></param>
    /// <param name="action"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void Run(int milliseconds, Func<Task> action)
    {
        // Check arguments
        if (milliseconds <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(milliseconds), milliseconds, "The milliseconds must be greater than to zero.");
        }

        ArgumentNullException.ThrowIfNull(action);

        // DebounceTask
        if (!_disposed)
        {
            _taskCompletionSource = _timer.Debounce(action, milliseconds);
        }
    }

    /// <summary>
    /// Delays the invocation of an action until a predetermined interval has elapsed since the last call.
    /// </summary>
    /// <param name="milliseconds"></param>
    /// <param name="action"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Task RunAsync(int milliseconds, Func<Task> action)
    {
        // Check arguments
        if (milliseconds <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(milliseconds), milliseconds, "The milliseconds must be greater than to zero.");
        }

        ArgumentNullException.ThrowIfNull(action);

        // DebounceTask
        if (!_disposed)
        {
            _taskCompletionSource = _timer.Debounce(action, milliseconds);
            return _taskCompletionSource.Task;
        }

        return Task.CompletedTask;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _taskCompletionSource = null;
            _timer.Dispose();
            _disposed = true;
        }
    }
}

/// <summary>
/// Extension methods for <see cref="System.Timers.Timer"/>.
/// </summary>
/// <remarks>
/// Inspired from Microsoft.Toolkit.Uwp.UI.DispatcherQueueTimerExtensions
/// </remarks>
internal static class DispatcherTimerExtensions
{
    private static readonly ConcurrentDictionary<System.Timers.Timer, TimerDebounceItem> _debounceInstances = new();

    /// <summary>
    /// Delays the invocation of an action until a predetermined interval has elapsed since the last call.
    /// </summary>
    /// <param name="timer"></param>
    /// <param name="action"></param>
    /// <param name="interval"></param>
    /// <returns></returns>
    public static TaskCompletionSource Debounce(this System.Timers.Timer timer, Func<Task> action, double interval)
    {
        // Check and stop any existing timer
        timer.Stop();

        // Reset timer parameters
        timer.Elapsed -= Timer_Elapsed;
        timer.Interval = interval;

        // If we're not in immediate mode, then we'll execute when the current timer expires.
        timer.Elapsed += Timer_Elapsed;

        var item = _debounceInstances.AddOrUpdate(
                        key: timer,
                        addValue: new TimerDebounceItem()
                        {
                            Status = new TaskCompletionSource(),
                            Action = action,
                        },
                        updateValueFactory: (k, v) =>
                        {
                            v.Status.SetCanceled();
                            v.Status = new TaskCompletionSource();
                            return v.UpdateAction(action);
                        });

        // Start the timer to keep track of the last call here.
        timer.Start();

        return item.Status;
    }

    /// <summary>
    /// Timer elapsed event handler.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private static void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
        // This event is only registered/run if we weren't in immediate mode above
        if (sender is System.Timers.Timer timer)
        {
            timer.Elapsed -= Timer_Elapsed;
            timer.Stop();

            if (_debounceInstances.TryRemove(timer, out var item))
            {
                if (item == null)
                {
                    return;
                }

                var task = item.Action.Invoke();
                task.ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        item.Status.SetException(t.Exception);
                    }
                    else if (t.IsCanceled)
                    {
                        item.Status.SetCanceled();
                    }
                    else
                    {
                        item.Status.SetResult();
                    }
                });
            }
        }
    }

    /// <summary>
    /// Timer debounce item.
    /// </summary>
    private sealed class TimerDebounceItem
    {
        /// <summary>
        /// Gets or sets the action to execute.
        /// </summary>
        public Func<Task> Action { get; set; } = default!;

        /// <summary>
        /// Gets the task completion source.
        /// </summary>
        public TaskCompletionSource Status { get; set; } = default!;

        /// <summary>
        /// Updates the action to execute.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public TimerDebounceItem UpdateAction(Func<Task> action)
        {
            Action = action;
            return this;
        }
    }
}