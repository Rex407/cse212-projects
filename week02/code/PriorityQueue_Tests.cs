using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
   [TestMethod]
// Scenario: Add three items with different priorities.
// Expected Result: Items are removed from highest priority to lowest priority.
// Defect(s) Found: The last item was not checked for highest priority and items were not removed from the queue.
public void TestPriorityQueue_1()
{
    var priorityQueue = new PriorityQueue();

    priorityQueue.Enqueue("A", 1);
    priorityQueue.Enqueue("B", 5);
    priorityQueue.Enqueue("C", 3);

    Assert.AreEqual("B", priorityQueue.Dequeue());
    Assert.AreEqual("C", priorityQueue.Dequeue());
    Assert.AreEqual("A", priorityQueue.Dequeue());
}

    [TestMethod]
// Scenario: Add two items with the same highest priority and then dequeue from an empty queue.
// Expected Result: The first item added with the highest priority is removed first (FIFO). An InvalidOperationException is thrown when the queue is empty.
// Defect(s) Found: Equal priorities did not follow FIFO order, and the queue should throw an InvalidOperationException when empty.
public void TestPriorityQueue_2()
{
    var priorityQueue = new PriorityQueue();

    priorityQueue.Enqueue("Bob", 5);
    priorityQueue.Enqueue("Sue", 5);

    Assert.AreEqual("Bob", priorityQueue.Dequeue());
    Assert.AreEqual("Sue", priorityQueue.Dequeue());

    try
    {
        priorityQueue.Dequeue();
        Assert.Fail("Exception should have been thrown.");
    }
    catch (InvalidOperationException e)
    {
        Assert.AreEqual("The queue is empty.", e.Message);
    }
}
    // Add more test cases as needed below.
}