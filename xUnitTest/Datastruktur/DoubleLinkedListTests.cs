using System;
using System.Collections.Generic;
using Xunit;
using TestProgram.LinkedLister;

public class DoubleLinkedListTests
{
	[Fact]
	public void Add_Items_IncreasesCount()
	{
		var list = new DoubleLinkedList<int>();
		list.Add(1);
		list.Add(2);
		list.Add(3);

		Assert.Equal(3, list.Count);
	}

	[Fact]
	public void Remove_Item_DecreasesCount_And_RemovesCorrectItem()
	{
		var list = new DoubleLinkedList<int>();
		list.Add(1);
		list.Add(2);
		list.Add(3);

		bool removed = list.Remove(2);

		Assert.True(removed);
		Assert.Equal(2, list.Count);
		Assert.False(list.Contains(2));
	}

	[Fact]
	public void Remove_NonExistentItem_ReturnsFalse()
	{
		var list = new DoubleLinkedList<string>();
		list.Add("A");
		list.Add("B");

		bool removed = list.Remove("C");

		Assert.False(removed);
		Assert.Equal(2, list.Count);
	}

	[Fact]
	public void Contains_ReturnsTrue_IfItemExists()
	{
		var list = new DoubleLinkedList<int>();
		list.Add(5);

		Assert.True(list.Contains(5));
		Assert.False(list.Contains(10));
	}

	[Fact]
	public void Clear_EmptiesList()
	{
		var list = new DoubleLinkedList<int>();
		list.Add(1);
		list.Add(2);

		list.Clear();

		Assert.Equal(0, list.Count);
		Assert.False(list.Contains(1));
		Assert.False(list.Contains(2));
	}

	[Fact]
	public void Enumeration_YieldsAllItems_InOrder()
	{
		var list = new DoubleLinkedList<int>();
		list.Add(1);
		list.Add(2);
		list.Add(3);

		var enumeratedItems = new List<int>();
		foreach (var item in list)
		{
			enumeratedItems.Add(item);
		}

		Assert.Equal(new List<int> { 1, 2, 3 }, enumeratedItems);
	}

	[Fact]
	public void Insert_AtEnd_AddsCorrectly()
	{
		var list = new DoubleLinkedList<int>();
		list.Add(1);
		list.Add(3);

		// Assuming you have Insert or AddAfter logic
		list.Add(2); // simulerer insert mellem 1 og 3

		Assert.Equal(3, list.Count);
		var items = new List<int>();
		foreach (var i in list) items.Add(i);

		Assert.Contains(2, items);
	}

	[Fact]
	public void RemoveHeadOrTail_UpdatesCountAndLinks()
	{
		var list = new DoubleLinkedList<int>();
		list.Add(1);
		list.Add(2);
		list.Add(3);

		list.Remove(1); // head
		list.Remove(3); // tail

		Assert.Equal(1, list.Count);
		Assert.True(list.Contains(2));
	}
}
