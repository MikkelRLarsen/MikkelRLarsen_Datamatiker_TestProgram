using HtmlAgilityPack;
using Org.BouncyCastle.Asn1.Pkcs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram.RingBuffers
{
	public class RingBuffer<T> where T : IEquatable<T>
	{
		private int _head;
		private int _maxCapacity;
		private int _currentCapacity;
		private T[] _array;

		public RingBuffer(int size)
		{
			_maxCapacity = size;
			_head = 0;
			_currentCapacity = 0;
			_array = new T[_maxCapacity];
		}

		public T this[int index]
		{
			get
			{
				return _array[GetActualIndex(index)];
			}

			set
			{
				_array[GetActualIndex(index)] = value;
			}
		}

		private int GetActualIndex(int index)
		{
			return (index + _head) % _maxCapacity;
		}

		public void Enqueue(T item)
		{
			// Check Resize Condition
			if (_currentCapacity >= _maxCapacity) 
				ResizeArray();

			// Sets item on tail via Math
			this[_currentCapacity] = item; 

			// HouseKeeping
			_currentCapacity++;
		}
		public void ResizeArray()
		{
			int newMaxCapacity = _maxCapacity * 2;

			T[] newArray = new T[newMaxCapacity];

			for(int i = 0; i < _currentCapacity; i++)
			{
				newArray[i] = this[i];
			}

			_maxCapacity = newMaxCapacity;
			_head = 0;
			_array = newArray;
		}

		public T? Dequeue()
		{
			//Check edgecases
			if (_currentCapacity is 0)
				return default;

			T value = _array[_head];

			// Remove head for Garbage Collection
			_array[_head] = default;

			// HouseKeeping
			_head = GetActualIndex(1);
			_currentCapacity--;

			return value;
		}

		public bool RemoveValue(T item)
		{

			// Checks if item is in array
			int itemIndex = -1;

			for(int i = 0; i < _currentCapacity; i++)
			{
				if (EqualityComparer<T>.Default.Equals(this[i], item))
				{
					itemIndex = i;
					break;
				}
			}

			if(itemIndex == -1) 
				return false;

			// Reorder rest of array
			for(int i = itemIndex; i < _currentCapacity; i++)
			{
				if(i == _currentCapacity - 1)
				{
					this[i] = default;
				}
				else
				{
					this[i] = this[i + 1];
				}
			}

			_currentCapacity--;
			return true;
		}
	}
}
