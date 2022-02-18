using System.Collections;
using System.Runtime.Serialization;
using MMS.LinkedList.Internal;

namespace MMS.LinkedList.Abstract;

public class MLinkedList<T> :
    ICollection<T>,
    IReadOnlyCollection<T>,
    ICollection,
    IDeserializationCallback,
    ISerializable
{
    private MLinkedListNode<T>? _head;
    private MLinkedListNode<T>? _tail;
    
    private int _count;

    public MLinkedList() { }

    public MLinkedList(T item)
    {
        Initialize(item);
    }
    
    private void Initialize(T item)
    {
        _tail = new MLinkedListNode<T>(item);
        _head = _tail;
        _count++;
    }

    public Action<T> ItemAdded;
    public Action<T> ItemRemoved;
    public Action Cleared;

    public void Add(T item)
    {
        AddLast(item);
    }

    public void AddLast(T item)
    {
        if (_tail is null)
        {
            Initialize(item);
        }
        else
        {
            var last = new MLinkedListNode<T>(item)
            {
                Prev = _tail
            };
            _tail.Next = last;
            _tail = last;
        }
        
        _count++;
        ItemAdded?.Invoke(item);
    }

    public void AddFirst(T item)
    {
        if (_head is null)
        {
            Initialize(item);
        }
        else
        {
            var first = new MLinkedListNode<T>(item)
            {
                Next = _head
            };
            _head.Prev = first;
            _head = first;
        }
        
        _count++;
        ItemAdded?.Invoke(item);
    }

    public void Clear()
    {
        _head = _tail = null;
        _count = 0;
        
        Cleared?.Invoke();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(Array array, int index)
    {
        throw new NotImplementedException();
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    int ICollection.Count => _count;
    int IReadOnlyCollection<T>.Count => _count;
    int ICollection<T>.Count => _count;

    public bool IsSynchronized => false;
    public object SyncRoot => this;
    public bool IsReadOnly => false;

    public void OnDeserialization(object? sender)
    {
        throw new NotImplementedException();
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        throw new NotImplementedException();
    }
}