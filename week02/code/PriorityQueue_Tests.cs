using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities, dequeue should return highest first
    // Expected Result: Items returned in order of priority (highest first)
    // Defect(s) Found: N/A
    public void TestPriorityQueue_1()
    {
        var queue = new PriorityQueue();
        queue.Enqueue(10, 1);  // value 10, priority 1
        queue.Enqueue(20, 3);  // value 20, priority 3
        queue.Enqueue(30, 2);  // value 30, priority 2

        Assert.AreEqual(20, queue.Dequeue());
        Assert.AreEqual(30, queue.Dequeue());
        Assert.AreEqual(10, queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add two items with same high priority, dequeue should follow FIFO
    // Expected Result: First enqueued item with highest priority is returned first
    // Defect(s) Found: N/A
    public void TestPriorityQueue_2()
    {
        var queue = new PriorityQueue();
        queue.Enqueue(100, 5);
        queue.Enqueue(200, 5); // same priority
        queue.Enqueue(300, 2);

        Assert.AreEqual(100, queue.Dequeue()); // FIFO for same priority
        Assert.AreEqual(200, queue.Dequeue());
        Assert.AreEqual(300, queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: Throws InvalidOperationException
    // Defect(s) Found: N/A
    public void TestPriorityQueue_EmptyQueue()
    {
        var queue = new PriorityQueue();
        var ex = Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    [TestMethod]
    // Scenario: Mixed priorities in queue
    // Expected Result: Highest priority items dequeued first, FIFO for same priority
    // Defect(s) Found: N/A
    public void TestPriorityQueue_MixedPriorities()
    {
        var queue = new PriorityQueue();
        queue.Enqueue(1, 1);
        queue.Enqueue(2, 3);
        queue.Enqueue(3, 2);
        queue.Enqueue(4, 3);

        Assert.AreEqual(2, queue.Dequeue()); // first 3
        Assert.AreEqual(4, queue.Dequeue()); // second 3
        Assert.AreEqual(3, queue.Dequeue()); // 2
        Assert.AreEqual(1, queue.Dequeue()); // 1
    }
}