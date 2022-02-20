using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Xunit;
using MMS.LinkedList;

namespace MMS.LinkedList.Test;

public class LinkedListTest
{
    private IMLinkedList<int> ll;

    public LinkedListTest()
    {
        ll = new MLinkedList<int>();
        
        ll.AddFirst(42);
        ll.AddLast(47);
        ll.AddAfter(42, 102);
    }
    
    [Fact]
    public void TestAddFirstChangesHead()
    {
        ll.AddFirst(1);
        Assert.Equal(1, ll.First);
    }
    
    [Fact]
    public void TestAddFirstDoesntChangesTail()
    {
        ll.AddFirst(2);

        ll.AddFirst(1);
        Assert.Equal(47, ll.Last);
    }
    
    [Fact]
    public void TestAddLastChangesTail()
    {
        ll.AddLast(1000);
        Assert.Equal(1000, ll.Last);
    }
    
    [Fact]
    public void TestAddAfterAddsInCorrectPosition()
    {
        ll.AddAfter(42, 1002);

        Assert.Equal(1002, ll[1]);
    }
    
    [Fact]
    public void TestCountIsCorrect()
    {
        Assert.Equal(3, ((ICollection<int>)ll).Count);
    }

    [Fact]
    public void TestOutOfRangeIsThrown()
    {
        Assert.Throws<IndexOutOfRangeException>(() => ll[100]);
    }
    
    [Fact]
    public void TestIndexSet()
    {
        ll[1] = 13;
        Assert.Equal(13, ll[1]);
    }

    [Fact]
    public void TestRemoveFirst()
    {
        ll.RemoveFirst();
        
        Assert.Equal(102, ll.First);
    }
    
    [Fact]
    public void TestRemoveLast()
    {
        ll.RemoveLast();
        
        Assert.Equal(102, ll.Last);
    }
    
    [Fact]
    public void TestRemoveAfter()
    {
        ll.RemoveAfter(102);
        
        Assert.Equal(102, ll.Last);
    }

    [Fact]
    public void TestToString()
    {
        Assert.Equal("42->102->47", ll.ToString());
    }
    
    [Fact]
    public void TestCopyToSuccess()
    {
        var arr = new int[3];
        ll.CopyTo(arr, 0);
        Assert.Equal(new int[]{ 42, 102, 47}, arr);
        
        ll.CopyTo((Array)arr, 0);
        Assert.Equal(new int[]{ 42, 102, 47}, arr);
    }
    
    [Fact]
    public void TestCopyToError()
    {
        Assert.Throws<ArgumentNullException>(() => ll.CopyTo(null!, 0));
        Assert.Throws<ArgumentOutOfRangeException>(() => ll.CopyTo(new int[3], -1));
        Assert.Throws<ArgumentOutOfRangeException>(() => ll.CopyTo(new int[3], 4));
        Assert.Throws<ArgumentException>(() => ll.CopyTo(new int[2], 0));
        
        Array a = new int[2];
        Assert.Throws<ArgumentOutOfRangeException>(() => ll.CopyTo(a, -1));
        Assert.Throws<ArgumentOutOfRangeException>(() => ll.CopyTo(a, 4));
        Assert.Throws<ArgumentException>(() => ll.CopyTo(a, 0));
    }
    
    
    [Fact]
    public void TestNewElementBothHeadTail()
    {
        ll = new MLinkedList<int>();
        
        ll.AddFirst(1);
        
        Assert.Equal(1, ll.First);
        Assert.Equal(1, ll.Last);
    }

    [Fact]
    public void TestNotSupportedOperations()
    {
        Assert.Throws<PlatformNotSupportedException>(() => ll.OnDeserialization(this));
        Assert.Throws<PlatformNotSupportedException>(() => ll.GetObjectData(null!, new StreamingContext()));
    }

    [Fact]
    public void TestClearedEventWhenRemovingLastNode()
    {
        ll = new MLinkedList<int>(1);
        var callCount = 0;
        ll.Cleared += () => callCount++;
        
        ll.RemoveFirst();
        
        Assert.Equal(1, callCount);
    }

    [Fact]
    public void TestAddRemoveEvents()
    {
        ll = new MLinkedList<int>();
        var callCountAdd = 0;
        var callCountRemove = 0;
        ll.ItemAdded += (_) => callCountAdd += _;
        ll.ItemAdded += (_) => callCountRemove -= _;
        
        ll.AddFirst(13);
        ll.RemoveFirst();
        
        Assert.Equal(13, callCountAdd);
        Assert.Equal(-13, callCountRemove);
    }

    [Fact]
    public void TestContains()
    {
        Assert.True(ll.Contains(42));
        Assert.False(ll.Contains(32));
    }

    [Fact]
    public void TestAddAddsToTail()
    {
        ll.Add(44);
        
        Assert.Equal(44, ll.Last);
    }

    [Fact]
    public void TestRemove()
    {
        Assert.True(ll.Contains(42));
        
        ll.Remove(42);
        
        Assert.False(ll.Contains(42));
    }

    [Fact]
    public void TestIndexAt()
    {
        Assert.Equal(0, ll.IndexOf(42));
        Assert.Equal(1, ll.IndexOf(102));
        Assert.Equal(2, ll.IndexOf(47));
    }

    [Fact]
    public void TestRemoveAtIndex()
    {
        Assert.True(ll.Contains(102));
        
        ll.RemoveAt(1);
        
        Assert.False(ll.Contains(102));
    }

    [Fact]
    public void TestClear()
    {
        var callCount = 0;
        ll.Cleared += () => callCount++;
        
        ll.Clear();
        
        Assert.Equal(1, callCount);
        Assert.Empty(ll);
    }

    [Fact]
    public void TestInterfaceProperties()
    {
        Assert.False(ll.IsSynchronized);
        Assert.Equal(ll, ll.SyncRoot);
        Assert.False(ll.IsReadOnly);
    }
}