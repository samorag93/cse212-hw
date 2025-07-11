using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Inserting elements with different priorities.
    // Expected Result: Dequeue returns the highest priority first.
    // Defect(s) Found: Fixed loop in Dequeue that ignored the last index. 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        // Assert.Fail("Implement the test case and then remove this.");
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Multiple items with the same priority.
    // Expected Result: The item added first is removed first (FIFO behavior).
    // Defect(s) Found: Used >= in loop, which broke FIFO order for ties (fixed). 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        // Assert.Fail("Implement the test case and then remove this.");
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown.
    // Defect(s) Found: None.
    public void TestPriorityQueue_EmptyQueue_Throws()
    {
        var priorityQueue = new PriorityQueue();
        var ex = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    [TestMethod]
    // Scenario: Mix of different priorities and ties.
    // Expected Result: Items are dequeued in correct priority order, and FIFO is respected for ties.
    // Defect(s) Found: FIFO was not respected for equal priorities (now fixed).
    public void TestPriorityQueue_MixedPrioritiesWithTies()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("One", 3);     // tie 3
        priorityQueue.Enqueue("Two", 10);    // highest
        priorityQueue.Enqueue("Three", 10);  // tie 10
        priorityQueue.Enqueue("Four", 2);    // lowest

        Assert.AreEqual("Two", priorityQueue.Dequeue());     // 10
        Assert.AreEqual("Three", priorityQueue.Dequeue());   // 10
        Assert.AreEqual("One", priorityQueue.Dequeue());     // 3
        Assert.AreEqual("Four", priorityQueue.Dequeue());    // 2

    }

    [TestMethod]
    // Scenario: Insert a single element.
    // Expected Result: That single item should be returned by Dequeue.
    // Defect(s) Found: None.
    public void TestPriorityQueue_SingleElement()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("OnlyOne", 99);
        Assert.AreEqual("OnlyOne", priorityQueue.Dequeue());
    }
    
}