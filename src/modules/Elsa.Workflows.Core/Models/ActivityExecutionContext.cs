using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Elsa.Expressions.Helpers;
using Elsa.Expressions.Models;
using Elsa.Workflows.Core.Services;

namespace Elsa.Workflows.Core.Models;

public class ActivityExecutionContext
{
    private readonly List<Bookmark> _bookmarks = new();
    private long _executionCount;

    public ActivityExecutionContext(
        WorkflowExecutionContext workflowExecutionContext,
        ActivityExecutionContext? parentActivityExecutionContext,
        ExpressionExecutionContext expressionExecutionContext,
        IActivity activity,
        CancellationToken cancellationToken)
    {
        WorkflowExecutionContext = workflowExecutionContext;
        ParentActivityExecutionContext = parentActivityExecutionContext;
        ExpressionExecutionContext = expressionExecutionContext;
        Activity = activity;
        CancellationToken = cancellationToken;
        Id = Guid.NewGuid().ToString();
    }

    public string Id { get; set; }
    public WorkflowExecutionContext WorkflowExecutionContext { get; }
    public ActivityExecutionContext? ParentActivityExecutionContext { get; internal set; }
    public ExpressionExecutionContext ExpressionExecutionContext { get; }

    /// <summary>
    /// The currently executing activity.
    /// </summary>
    public IActivity Activity { get; set; }

    /// <summary>
    /// A cancellation token to use when invoking asynchronous operations.
    /// </summary>
    public CancellationToken CancellationToken { get; }

    /// <summary>
    /// A dictionary of values that can be associated with this activity execution context.
    /// </summary>
    public IDictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();

    /// <summary>
    /// A transient dictionary of values that can be associated with this activity execution context.
    /// These properties only exist while the activity executes and are not persisted. 
    /// </summary>
    public IDictionary<object, object> TransientProperties { get; set; } = new Dictionary<object, object>();

    /// <summary>
    /// Returns the <see cref="ActivityNode"/> metadata about the current activity.
    /// </summary>
    public ActivityNode ActivityNode => WorkflowExecutionContext.FindNodeByActivity(Activity);

    /// <summary>
    /// A list of bookmarks created by the current activity.
    /// </summary>
    public IReadOnlyCollection<Bookmark> Bookmarks => new ReadOnlyCollection<Bookmark>(_bookmarks);

    /// <summary>
    /// The number of times this <see cref="ActivityExecutionContext"/> has executed.
    /// </summary>
    public long ExecutionCount => _executionCount;

    /// <summary>
    /// Gets or sets a value that indicates if the workflow should continue executing or not.
    /// </summary>
    public bool Continue { get; private set; } = true;

    /// <summary>
    /// A dictionary of received inputs.
    /// </summary>
    public IDictionary<string, object> Input => WorkflowExecutionContext.Input;

    /// <summary>
    /// Journal data will be added to the workflow execution log for the "Executed" event.  
    /// </summary>
    // ReSharper disable once CollectionNeverQueried.Global
    public IDictionary<string, object?> JournalData { get; } = new Dictionary<string, object?>();

    public void ScheduleActivity(IActivity? activity, ActivityCompletionCallback? completionCallback = default, IEnumerable<MemoryBlockReference>? references = default, object? tag = default)
    {
        if (activity == null)
            return;

        WorkflowExecutionContext.Schedule(activity, this, completionCallback, references, tag);
    }

    public void ScheduleActivity(IActivity? activity, ActivityExecutionContext owner, ActivityCompletionCallback? completionCallback = default, IEnumerable<MemoryBlockReference>? references = default, object? tag = default)
    {
        if (activity == null)
            return;

        WorkflowExecutionContext.Schedule(activity, owner, completionCallback, references, tag);
    }

    public void ScheduleActivities(params IActivity?[] activities) => ScheduleActivities((IEnumerable<IActivity?>)activities);

    public void ScheduleActivities(IEnumerable<IActivity?> activities, ActivityCompletionCallback? completionCallback = default)
    {
        foreach (var activity in activities)
            ScheduleActivity(activity, completionCallback);
    }

    public void CreateBookmarks(IEnumerable<object> payloads, ExecuteActivityDelegate? callback = default)
    {
        foreach (var payload in payloads)
            CreateBookmark(payload, callback);
    }

    public void AddBookmarks(IEnumerable<Bookmark> bookmarks) => _bookmarks.AddRange(bookmarks);
    public void AddBookmark(Bookmark bookmark) => _bookmarks.Add(bookmark);

    public Bookmark CreateBookmark(ExecuteActivityDelegate callback) => CreateBookmark(default, callback);

    /// <summary>
    /// Creates a bookmark so that this activity can be resumed at a later time.
    /// Creating a bookmark will automatically suspend the workflow after all pending activities have executed.
    /// </summary>
    public Bookmark CreateBookmark(object? payload = default, ExecuteActivityDelegate? callback = default)
    {
        var bookmarkHasher = GetRequiredService<IBookmarkHasher>();
        var identityGenerator = GetRequiredService<IIdentityGenerator>();
        var payloadSerializer = GetRequiredService<IBookmarkPayloadSerializer>();
        var payloadJson = payload != null ? payloadSerializer.Serialize(payload) : default;
        var hash = bookmarkHasher.Hash(Activity.Type, payloadJson);

        var bookmark = new Bookmark(
            identityGenerator.GenerateId(),
            Activity.Type,
            hash,
            payloadJson,
            Activity.Id,
            Id,
            callback?.Method.Name);

        AddBookmark(bookmark);
        return bookmark;
    }

    /// <summary>
    /// Clear all bookmarks.
    /// </summary>
    public void ClearBookmarks() => _bookmarks.Clear();

    /// <summary>
    /// Returns a property value associated with the current activity context. 
    /// </summary>
    public T? GetProperty<T>(string key) => Properties!.TryGetValue<T?>(key, out var value) ? value : default;

    /// <summary>
    /// Returns a property value associated with the current activity context. 
    /// </summary>
    public T GetProperty<T>(string key, Func<T> defaultValue)
    {
        if (Properties.TryGetValue<T?>(key, out var value))
            return value!;

        value = defaultValue();
        Properties[key] = value!;

        return value!;
    }

    /// <summary>
    /// Stores a property associated with the current activity context. 
    /// </summary>
    public void SetProperty<T>(string key, T? value) => Properties[key] = value!;

    /// <summary>
    /// Updates a property associated with the current activity context. 
    /// </summary>
    public T UpdateProperty<T>(string key, Func<T?, T> updater) where T : notnull
    {
        var value = GetProperty<T?>(key);
        value = updater(value);
        Properties[key] = value;
        return value;
    }

    public T GetRequiredService<T>() where T : notnull => WorkflowExecutionContext.GetRequiredService<T>();
    public object GetRequiredService(Type serviceType) => WorkflowExecutionContext.GetRequiredService(serviceType);
    public T GetOrCreateService<T>() where T : notnull => WorkflowExecutionContext.GetOrCreateService<T>();
    public object GetOrCreateService(Type serviceType) => WorkflowExecutionContext.GetOrCreateService(serviceType);
    public T? GetService<T>() where T : notnull => WorkflowExecutionContext.GetService<T>();
    public IEnumerable<T> GetServices<T>() where T : notnull => WorkflowExecutionContext.GetServices<T>();
    public object? GetService(Type serviceType) => WorkflowExecutionContext.GetService(serviceType);
    public T? Get<T>(Input<T>? input) => input == null ? default : Get<T>(input.MemoryBlockReference());

    public object? Get(MemoryBlockReference blockReference)
    {
        var location = GetBlock(blockReference) ?? throw new InvalidOperationException($"No location found with ID {blockReference.Id}. Did you forget to declare a variable with a container?");
        return location.Value;
    }

    public T? Get<T>(MemoryBlockReference blockReference)
    {
        var value = Get(blockReference);
        return value != default ? value.ConvertTo<T>() : default;
    }

    public void Set(MemoryBlockReference blockReference, object? value) => ExpressionExecutionContext.Set(blockReference, value);
    public void Set(Output? output, object? value) => ExpressionExecutionContext.Set(output, value);
    public void Set<T>(Output<T>? output, T value) => ExpressionExecutionContext.Set(output, value);

    /// <summary>
    /// Stops further execution of the workflow.
    /// </summary>
    public void PreventContinuation() => Continue = false;

    /// <summary>
    /// Removes all completion callbacks for the current activity.
    /// </summary>
    public void ClearCompletionCallbacks()
    {
        var entriesToRemove = WorkflowExecutionContext.CompletionCallbacks.Where(x => x.Owner == this);
        WorkflowExecutionContext.RemoveCompletionCallbacks(entriesToRemove);
    }

    internal void IncrementExecutionCount() => _executionCount++;

    private MemoryBlock? GetBlock(MemoryBlockReference locationBlockReference) =>
        ExpressionExecutionContext.Memory.TryGetBlock(locationBlockReference.Id, out var location)
            ? location
            : ParentActivityExecutionContext?.GetBlock(locationBlockReference);
}