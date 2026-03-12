using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram.Heaps
{
    public class MinHeapBenchmark
    {
        // Dynamiske milestones: 1k, 2k, 5k, 10k, 20k, 50k, ...
        private static IEnumerable<int> GenerateMilestones(int totalElements)
        {
            int milestone = 1000;
            while (milestone < totalElements)
            {
                yield return milestone;
                milestone = (int)(milestone * 2.5); // vælg faktor 2.5 for progression
            }
            yield return totalElements;
        }

        public static void RunBenchmark(int totalElements = 10000)
        {
            IMinHeap<int> heap = new MinHeap<int>();
            Random rnd = new Random();

            Stopwatch sw = new Stopwatch();
            Console.WriteLine($"=== Benchmark: Enqueue {totalElements} elements ===");

            sw.Start();
            foreach (int i in GenerateRange(totalElements))
            {
                int priority = rnd.Next(0, totalElements);
                heap.Enqueue(priority, priority);

                if (IsMilestone(i, totalElements))
                    Console.WriteLine($"Enqueued {i} elements, elapsed: {sw.ElapsedMilliseconds} ms");
            }
            sw.Stop();
            Console.WriteLine($"Total enqueue time: {sw.ElapsedMilliseconds} ms\n");

            Console.WriteLine($"=== Benchmark: Dequeue {totalElements} elements ===");
            sw.Restart();
            foreach (int i in GenerateRange(totalElements))
            {
                heap.Dequeue();

                if (IsMilestone(i, totalElements))
                    Console.WriteLine($"Dequeued {i} elements, elapsed: {sw.ElapsedMilliseconds} ms");
            }
            sw.Stop();
            Console.WriteLine($"Total dequeue time: {sw.ElapsedMilliseconds} ms");
        }

        private static IEnumerable<int> GenerateRange(int total)
        {
            for (int i = 1; i <= total; i++)
                yield return i;
        }

        private static bool IsMilestone(int current, int total)
        {
            foreach (var m in GenerateMilestones(total))
            {
                if (current == m) return true;
            }
            return false;
        }

        public static void RunParallelBenchmark(int totalElementsPerThread = 10000, int threadCount = 4)
        {
            IMinHeap<int> heap = new MinHeap<int>();
            Random rnd = new Random();

            Console.WriteLine($"=== Parallel Benchmark: {threadCount} threads, {totalElementsPerThread} elements each ===");

            Stopwatch sw = Stopwatch.StartNew();

            Parallel.For(0, threadCount, t =>
            {
                Random threadRnd = new Random(Guid.NewGuid().GetHashCode());
                for (int i = 0; i < totalElementsPerThread; i++)
                {
                    int priority = threadRnd.Next(0, totalElementsPerThread);
                    heap.Enqueue(priority, priority);

                    if (t == 0 && IsMilestone(i + 1, totalElementsPerThread))
                        Console.WriteLine($"Thread 0 enqueued {i + 1} elements, elapsed: {sw.ElapsedMilliseconds} ms");
                }
            });

            sw.Stop();
            Console.WriteLine($"Total enqueue time: {sw.ElapsedMilliseconds} ms\n");

            Console.WriteLine($"=== Parallel Dequeue Benchmark ===");

            int totalElements = totalElementsPerThread * threadCount;
            List<int> dequeuedItems = new List<int>();
            object listLock = new object();

            sw.Restart();
            Parallel.For(0, threadCount, t =>
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
                        break;
                    }

                    lock (listLock)
                    {
                        dequeuedItems.Add(value);

                        if (t == 0 && IsMilestone(dequeuedItems.Count, totalElements))
                            Console.WriteLine($"Thread 0 dequeued {dequeuedItems.Count} elements, elapsed: {sw.ElapsedMilliseconds} ms");
                    }
                }
            });

            sw.Stop();
            Console.WriteLine($"Total dequeue time: {sw.ElapsedMilliseconds} ms");

            if (dequeuedItems.Count != totalElements)
                Console.WriteLine($"Warning: Expected {totalElements} dequeued, got {dequeuedItems.Count}");
            else
                Console.WriteLine("All elements successfully dequeued.");
        }
    }
}
