using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestProgram.SearchTrees.BinarySeachTree;

namespace TestProgram.LinkedLister
{
	public class LinkedListNode<T>
	{
		public T Value { get; set; }
		public LinkedListNode<T>? Next { get; set; } = null;
		public LinkedListNode<T>? Prev { get; set; } = null;
		public DoubleLinkedList<T>? LinkedList { get; set; }

		public LinkedListNode(T value)
		{
			Value = value;
		}

		public void RemoveNode()
		{
			Prev = Next;
			if (Next != null) Next.Prev = Prev;
		}
	}

	public class DoubleLinkedList<T> : IList<T>, IEnumerable<T>
	{
		private int _length;
		private LinkedListNode<T>? _head;
		private LinkedListNode<T>? _tail;

		public DoubleLinkedList()
		{
			_length = 0;
			_head = null;
			_tail = null;
		}

		public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public int Count => _length;

		public bool IsReadOnly => false;

		public void Add(T item)
		{
			_length++;

			var newNode = new LinkedListNode<T>(item);
			if (_head is null && _tail is null)
			{
				_head = _tail = newNode;
			}
			else
			{
				_tail!.Next = newNode;
				_tail = newNode;
			}
		}

		public void Clear()
		{
			_head = _tail = null;
			_length = 0;
		}

		public bool Contains(T item)
		{
			if (_head is null || _tail is null)
			{
				return false; 
			}

			LinkedListNode<T> curr = _head;

			for(int i = 0; i < _length; i++)
			{
				if (EqualityComparer<T>.Default.Equals(curr!.Value, item)) return true;

				curr = curr.Next;
			}

			return false;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			if (arrayIndex > this._length) throw new Exception();
			if (arrayIndex < 0) throw new Exception();


			LinkedListNode<T>? firstMadeNode = null;
			LinkedListNode<T>? prevMadeNode = null;

			foreach (var value in array)
			{
				_length++;
				var newNode = new LinkedListNode<T>(value);
				if (firstMadeNode == null) firstMadeNode = newNode;

				if (prevMadeNode != null)
				{
					newNode.Prev = prevMadeNode;
					if (prevMadeNode.Next != null) prevMadeNode.Next.Prev = newNode;
					prevMadeNode.Next = newNode;
				}

				prevMadeNode = newNode;
			}

			if (arrayIndex == 0)
			{
				_head.Prev = prevMadeNode;
				_head = firstMadeNode;
			}
			else if (arrayIndex == _length-1)
			{
				_tail.Next = firstMadeNode;
				_tail = prevMadeNode;
			}
			else
			{
				var curr = _head;
				for(int i = 0; i < arrayIndex; i++)
				{
					curr = curr.Next;
				}

				firstMadeNode.Prev = curr;
				prevMadeNode.Next = curr.Next;

				curr.Next = firstMadeNode;
				if(prevMadeNode.Next != null) prevMadeNode.Next.Prev = prevMadeNode;
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			LinkedListNode<T> curr = _head;
			for (int i = 0; i < _length; i++)
			{
				yield return curr.Value;
				curr = curr.Next;
			}
		}

		public int IndexOf(T item)
		{
			if (_head is null || _tail is null)
			{
				return -1;
			}

			LinkedListNode<T> curr = _head;

			for (int i = 0; i < _length; i++)
			{
				if (EqualityComparer<T>.Default.Equals(curr!.Value, item)) return i;

				curr = curr.Next;
			}

			return -1;
		}

		public void Insert(int index, T item)
		{
			if (_head is null || _tail is null)
			{
				throw new Exception();
			}

			_length++;

			LinkedListNode<T> curr = _head;
			for (int i = 0; i < index; i++)
			{
				curr = curr.Next;
			}

			var newMadeNode = new LinkedListNode<T>(item);
			newMadeNode.Prev = curr;
			newMadeNode.Next = curr.Next;
			curr.Next = newMadeNode;
			if (newMadeNode.Next != null) newMadeNode.Next.Prev = newMadeNode;
		}

		public bool Remove(T item)
		{
			if (_head is null || _tail is null)
			{
				return false;
			}

			LinkedListNode<T> curr = _head;
			bool found = false;

			for (int i = 0; i < _length; i++)
			{
				if (EqualityComparer<T>.Default.Equals(curr!.Value, item))
				{
					found = true;
					break;
				}

				curr = curr.Next;
			}

			if (found is false) return false;
			else
			{
				_length--;
				curr.RemoveNode();
				return true;
			}
		}

		public void RemoveAt(int index)
		{
			LinkedListNode<T> curr = _head;
			for (int i = 0; i < index; i++)
			{
				curr = curr.Next;
			}

			_length--;
			curr.RemoveNode();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
			var n = new List<T>();
		}
		public void Enqueue(T item)
		{
			throw new NotImplementedException();
		}
		public void Dequeue()
		{
			throw new NotImplementedException(); 
		}
		public void Peak()
		{
			throw new NotImplementedException();
		}
		public void Append(T item)
		{
			throw new NotImplementedException(); 
		}
		public void Prepend(T item)
		{
			throw new NotImplementedException(); 
		}
	}
}
