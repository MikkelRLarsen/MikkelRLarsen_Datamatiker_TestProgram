using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram.Heaps
{

    public interface IMinHeap<T> where T : class
    {
        public T Peek();
        public T Dequeue();
        public void Enqueue(int priority, T item);

    }
    public class MinHeap<T> : IMinHeap<T> where T : class
    {

        private class HeapValues
        {
            public int Priority { get; set; }
            public T ClassValue { get; set; }

            public HeapValues(int priority, T classValue)
            {
                Priority = priority;
                ClassValue = classValue;
            }
        }

        private List<HeapValues> _heap = new List<HeapValues>();

        public T Peek()
        {
            if (_heap.Count == 0) throw new InvalidOperationException("Heap is empty");

            return _heap[0].ClassValue;
        }

        public T Dequeue()
        {
            if (_heap.Count == 0) throw new InvalidOperationException("Heap is empty");

            T returnValue = _heap[0].ClassValue;

            if (_heap.Count == 1)
            {
                _heap.RemoveAt(0);
                return returnValue;
            }

            int lastElementIndex = _heap.Count - 1;

            Swap(0, lastElementIndex);

            _heap.RemoveAt(lastElementIndex);

            HeapifyDown();

            return returnValue;   
        }

        public void Enqueue(int priority, T item)
        {
            HeapValues newValues = new HeapValues(priority, item);

            _heap.Add(newValues);

            HeapifyUp();
        }

        private void HeapifyDown()
        {
            int index = 0;

            while(true)
            {
                int leftChild = GetIndex(Index.LeftChild, index);
                int rightChild = GetIndex(Index.RightChild, index);

                // Checks if any child exists
                if (leftChild >= _heap.Count) break;

                int compareIndex = leftChild;

                // Checks if right child exist and is smaller then the left
                if (rightChild < _heap.Count &&
                    _heap[rightChild].Priority < _heap[leftChild].Priority)
                {
                    compareIndex = rightChild;
                }

                if (_heap[index].Priority < _heap[compareIndex].Priority) break;

                Swap(index, compareIndex);

                index = compareIndex;
            }
        }
        private void HeapifyUp()
        {
            int index = _heap.Count - 1;

            while(index > 0)
            {

                int parentIndex = GetIndex(Index.Parent, index);

                if (_heap[index].Priority > 
                    _heap[parentIndex].Priority)
                {
                    break;
                }

                Swap(index, parentIndex);

                index = parentIndex;
            }
        }

        private void Swap(int indexOne, int indexTwo)
        {
            HeapValues heapValueOne = _heap[indexOne];
            HeapValues heapValueTwo = _heap[indexTwo];

            _heap[indexOne] = heapValueTwo;
            _heap[indexTwo] = heapValueOne;
        }

        private enum Index
        {
            Parent,
            LeftChild,
            RightChild
        }
        private int GetIndex(Index target, int currentIndex)
        {
            if (target == Index.Parent) return (currentIndex - 1) / 2;
            if (target == Index.LeftChild) return (currentIndex * 2) + 1;
            if (target == Index.RightChild) return ( currentIndex * 2) + 2;

            return -1;
        }
    }
}
