public class PriorityQueue
{
    private class QueueItem
    {
        public int Value { get; }
        public int Priority { get; }

        public QueueItem(int value, int priority)
        {
            Value = value;
            Priority = priority;
        }
    }

    private readonly List<QueueItem> _items = new();

    public int Length => _items.Count;

    /// <summary>
    /// Add an item to the back of the queue.
    /// </summary>
    public void Enqueue(int value, int priority)
    {
        _items.Add(new QueueItem(value, priority));
    }

    /// <summary>
    /// Remove and return the value with the highest priority. FIFO if multiple.
    /// </summary>
    public int Dequeue()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        // Find index of first item with highest priority
        int maxPriority = _items.Max(item => item.Priority);
        int index = _items.FindIndex(item => item.Priority == maxPriority);

        int value = _items[index].Value;
        _items.RemoveAt(index);
        return value;
    }

    public override string ToString()
    {
        return string.Join(", ", _items.Select(i => $"({i.Value},{i.Priority})"));
    }
}