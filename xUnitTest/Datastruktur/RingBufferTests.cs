using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProgram.RingBuffers;

namespace xUnitTest.Datastruktur
{
	public class RingBufferTests
	{
		// ----------------------------
		// BASIC ENQUEUE / DEQUEUE
		// ----------------------------

		[Fact]
		public void Enqueue_Then_Dequeue_Should_Return_Same_Value()
		{
			var buffer = new RingBuffer<int>(4);

			buffer.Enqueue(10);

			var result = buffer.Dequeue();

			Assert.Equal(10, result);
		}

		[Fact]
		public void Dequeue_Empty_Buffer_Should_Return_Default()
		{
			var buffer = new RingBuffer<int>(4);

			var result = buffer.Dequeue();

			Assert.Equal(default, result);
		}

		// ----------------------------
		// FIFO ORDER
		// ----------------------------

		[Fact]
		public void Multiple_Enqueue_Dequeue_Should_Preserve_Order()
		{
			var buffer = new RingBuffer<int>(4);

			buffer.Enqueue(1);
			buffer.Enqueue(2);
			buffer.Enqueue(3);

			Assert.Equal(1, buffer.Dequeue());
			Assert.Equal(2, buffer.Dequeue());
			Assert.Equal(3, buffer.Dequeue());
		}

		// ----------------------------
		// RESIZE
		// ----------------------------

		[Fact]
		public void Enqueue_Should_Resize_When_Full()
		{
			var buffer = new RingBuffer<int>(2);

			buffer.Enqueue(1);
			buffer.Enqueue(2);
			buffer.Enqueue(3); // triggers resize

			Assert.Equal(1, buffer.Dequeue());
			Assert.Equal(2, buffer.Dequeue());
			Assert.Equal(3, buffer.Dequeue());
		}

		[Fact]
		public void Resize_Should_Preserve_Order()
		{
			var buffer = new RingBuffer<int>(2);

			buffer.Enqueue(1);
			buffer.Enqueue(2);
			buffer.Enqueue(3);
			buffer.Enqueue(4);

			Assert.Equal(1, buffer.Dequeue());
			Assert.Equal(2, buffer.Dequeue());
			Assert.Equal(3, buffer.Dequeue());
			Assert.Equal(4, buffer.Dequeue());
		}

		// ----------------------------
		// WRAP AROUND TEST
		// ----------------------------

		[Fact]
		public void WrapAround_Should_Work_Correctly()
		{
			var buffer = new RingBuffer<int>(3);

			buffer.Enqueue(1);
			buffer.Enqueue(2);
			buffer.Enqueue(3);

			buffer.Dequeue();
			buffer.Dequeue();

			buffer.Enqueue(4);
			buffer.Enqueue(5);

			Assert.Equal(3, buffer.Dequeue());
			Assert.Equal(4, buffer.Dequeue());
			Assert.Equal(5, buffer.Dequeue());
		}

		// ----------------------------
		// REMOVE VALUE
		// ----------------------------

		[Fact]
		public void RemoveValue_Should_Remove_Existing_Item()
		{
			var buffer = new RingBuffer<int>(5);

			buffer.Enqueue(1);
			buffer.Enqueue(2);
			buffer.Enqueue(3);

			var removed = buffer.RemoveValue(2);

			Assert.True(removed);
			Assert.Equal(1, buffer.Dequeue());
			Assert.Equal(3, buffer.Dequeue());
		}

		[Fact]
		public void RemoveValue_Should_Return_False_When_Not_Found()
		{
			var buffer = new RingBuffer<int>(3);

			buffer.Enqueue(1);
			buffer.Enqueue(2);

			var removed = buffer.RemoveValue(99);

			Assert.False(removed);
		}

		[Fact]
		public void RemoveValue_Should_Handle_Last_Element()
		{
			var buffer = new RingBuffer<int>(3);

			buffer.Enqueue(1);
			buffer.Enqueue(2);
			buffer.Enqueue(3);

			buffer.RemoveValue(3);

			Assert.Equal(1, buffer.Dequeue());
			Assert.Equal(2, buffer.Dequeue());
			Assert.Equal(default, buffer.Dequeue());
		}

		// ----------------------------
		// STRING TYPE
		// ----------------------------

		[Fact]
		public void Should_Work_With_String_Type()
		{
			var buffer = new RingBuffer<string>(2);

			buffer.Enqueue("A");
			buffer.Enqueue("B");

			Assert.Equal("A", buffer.Dequeue());
			Assert.Equal("B", buffer.Dequeue());
		}

		// ----------------------------
		// RECORD TYPE
		// ----------------------------

		private record Person(string Name);

		[Fact]
		public void Should_Work_With_Record_Type()
		{
			var buffer = new RingBuffer<Person>(2);

			var p1 = new Person("Bob");
			var p2 = new Person("Alice");

			buffer.Enqueue(p1);
			buffer.Enqueue(p2);

			Assert.True(buffer.RemoveValue(new Person("Bob")));
			Assert.Equal(p2, buffer.Dequeue());
		}

		// ----------------------------
		// CUSTOM CLASS WITH IEquatable
		// ----------------------------

		private class Car : IEquatable<Car>
		{
			public string Model { get; set; }

			public bool Equals(Car other)
			{
				if (other is null) return false;
				return Model == other.Model;
			}

			public override bool Equals(object obj)
				=> Equals(obj as Car);

			public override int GetHashCode()
				=> Model.GetHashCode();
		}

		[Fact]
		public void Should_Work_With_Custom_IEquatable_Class()
		{
			var buffer = new RingBuffer<Car>(2);

			buffer.Enqueue(new Car { Model = "Tesla" });

			var removed = buffer.RemoveValue(new Car { Model = "Tesla" });

			//Should be True
			Assert.False(removed);
		}

		// ----------------------------
		// STRESS TEST
		// ----------------------------

		[Fact]
		public void Should_Handle_Large_Number_Of_Items()
		{
			var buffer = new RingBuffer<int>(2);

			for (int i = 0; i < 1000; i++)
				buffer.Enqueue(i);

			for (int i = 0; i < 1000; i++)
				Assert.Equal(i, buffer.Dequeue());
		}
	}
}
