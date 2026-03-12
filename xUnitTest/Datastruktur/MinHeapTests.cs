using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProgram.Heaps;

namespace xUnitTest.Datastruktur
{
    public class MinHeapTests
    {
        // Helper for at tjekke at heap-prioriteter stiger
        private void AssertHeapOrder(IEnumerator<HeapItem> heapEnumerator)
        {
            int previous = int.MinValue;
            while (heapEnumerator.MoveNext())
            {
                int current = heapEnumerator.Current.Priority;
                Assert.True(current >= previous, $"Heap property violated: {current} < {previous}");
                previous = current;
            }
        }

        private class HeapItem
        {
            public string Value { get; set; }
            public int Priority { get; set; }
        }

        [Fact]
        public void Enqueue_SingleItem_PeekReturnsThatItem()
        {
            IMinHeap<string> heap = new MinHeap<string>();
            heap.Enqueue(5, "A");

            Assert.Equal("A", heap.Peek());
        }

        [Fact]
        public void Enqueue_MultipleItems_PeekReturnsMinimumPriority()
        {
            IMinHeap<string> heap = new MinHeap<string>();
            heap.Enqueue(10, "B");
            heap.Enqueue(3, "C");
            heap.Enqueue(7, "D");

            // Mindste priority = 3 → "C"
            Assert.Equal("C", heap.Peek());
        }

        [Fact]
        public void Dequeue_ReturnsItemsInNonDecreasingPriorityOrder()
        {
            IMinHeap<string> heap = new MinHeap<string>();
            heap.Enqueue(5, "A");
            heap.Enqueue(2, "B");
            heap.Enqueue(8, "C");
            heap.Enqueue(1, "D");

            int previous = int.MinValue;
            while (true)
            {
                try
                {
                    string item = heap.Dequeue();
                    int priority = 0;
                    switch (item)
                    {
                        case "D": priority = 1; break;
                        case "B": priority = 2; break;
                        case "A": priority = 5; break;
                        case "C": priority = 8; break;
                    }
                    Assert.True(priority >= previous, $"Heap property violated: {priority} < {previous}");
                    previous = priority;
                }
                catch (InvalidOperationException)
                {
                    break;
                }
            }

            // Heap should now be empty
            Assert.Throws<InvalidOperationException>(() => heap.Peek());
            Assert.Throws<InvalidOperationException>(() => heap.Dequeue());
        }

        [Fact]
        public void Peek_OnEmptyHeap_ThrowsException()
        {
            IMinHeap<string> heap = new MinHeap<string>();
            Assert.Throws<InvalidOperationException>(() => heap.Peek());
        }

        [Fact]
        public void Dequeue_OnEmptyHeap_ThrowsException()
        {
            IMinHeap<string> heap = new MinHeap<string>();
            Assert.Throws<InvalidOperationException>(() => heap.Dequeue());
        }

        [Fact]
        public void Enqueue_DuplicatePriorities_OrderNotGuaranteed()
        {
            IMinHeap<string> heap = new MinHeap<string>();
            heap.Enqueue(5, "A");
            heap.Enqueue(5, "B");
            heap.Enqueue(5, "C");

            // Alle har samme priority → bare test at alle elementer returneres
            var items = new List<string>();
            while (true)
            {
                try
                {
                    items.Add(heap.Dequeue());
                }
                catch (InvalidOperationException)
                {
                    break;
                }
            }

            Assert.Contains("A", items);
            Assert.Contains("B", items);
            Assert.Contains("C", items);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void Enqueue_Dequeue_MixedPriorities_PriorityOrderCorrect()
        {
            IMinHeap<string> heap = new MinHeap<string>();
            heap.Enqueue(10, "A");
            heap.Enqueue(5, "B");
            heap.Enqueue(10, "C");
            heap.Enqueue(1, "D");
            heap.Enqueue(5, "E");

            int previous = int.MinValue;
            while (true)
            {
                try
                {
                    string item = heap.Dequeue();
                    int priority = item switch
                    {
                        "D" => 1,
                        "B" => 5,
                        "E" => 5,
                        "A" => 10,
                        "C" => 10,
                        _ => throw new Exception("Unknown item")
                    };

                    Assert.True(priority >= previous, $"Heap property violated: {priority} < {previous}");
                    previous = priority;
                }
                catch (InvalidOperationException)
                {
                    break;
                }
            }
        }

        [Fact]
        public void Enqueue_ConcurrentOperations_HeapRemainsValid()
        {
            IMinHeap<int> heap = new MinHeap<int>();
            int itemCount = 1000;

            // Start 4 samtidige tråde der enqueuer
            Parallel.For(0, 4, t =>
            {
                for (int i = 0; i < itemCount; i++)
                {
                    heap.Enqueue(i, i);
                }
            });

            // Tæl alle elementer og tjek min-priority
            int totalCount = 4 * itemCount;
            int previous = int.MinValue;
            var results = new List<int>();
            for (int i = 0; i < totalCount; i++)
            {
                int value = heap.Dequeue();
                Assert.True(value >= previous, $"Heap property violated: {value} < {previous}");
                previous = value;
                results.Add(value);
            }

            // Heap should now be empty
            Assert.Throws<InvalidOperationException>(() => heap.Dequeue());
            Assert.Throws<InvalidOperationException>(() => heap.Peek());

            // Alle forventede værdier er med
            Assert.Equal(totalCount, results.Count);
        }

        [Fact]
        public void Dequeue_ConcurrentOperations_HeapRemainsValid()
        {
            IMinHeap<int> heap = new MinHeap<int>();
            int itemCount = 1000;

            // Først fyld heap med elementer
            for (int i = 0; i < itemCount; i++)
                heap.Enqueue(i, i);

            var results = new List<int>();
            object resultsLock = new object();

            // Start 4 samtidige tråde der dequeuer
            Parallel.For(0, 4, t =>
            {
                while (true)
                {
                    int value;
                    try
                    {
                        value = heap.Dequeue();
                    }
                    catch (InvalidOperationException)
                    {
                        break; // ingen elementer tilbage
                    }

                    lock (resultsLock)
                    {
                        results.Add(value);
                    }
                }
            });

            // Tjek at alle elementer er returneret i korrekt rækkefølge
            results.Sort();
            for (int i = 0; i < itemCount; i++)
            {
                Assert.Equal(i, results[i]);
            }
        }

        [Fact]
        public void Mixed_ConcurrentEnqueueDequeue_HeapPropertyMaintained()
        {
            IMinHeap<int> heap = new MinHeap<int>();
            int enqueueCount = 1000;
            int dequeueCount = 1000;

            Parallel.Invoke(
                () =>
                {
                    for (int i = 0; i < enqueueCount; i++)
                        heap.Enqueue(i, i);
                },
                () =>
                {
                    for (int i = 0; i < dequeueCount; i++)
                    {
                        try { heap.Dequeue(); }
                        catch (InvalidOperationException) { } // ignorer tom heap
                    }
                }
            );

            // Efter samtidige operationer må heapen stadig ikke være korrupt
            while (true)
            {
                try
                {
                    int current = heap.Dequeue();
                    if (heap.Peek() != null) // næste element skal være >= current
                    {
                        Assert.True(heap.Peek() >= current, "Heap property violated after concurrent operations");
                    }
                }
                catch (InvalidOperationException)
                {
                    break;
                }
            }
        }
    }
}

