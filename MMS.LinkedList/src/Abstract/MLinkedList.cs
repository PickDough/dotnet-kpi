using System.Collections;
using System.Runtime.Serialization;
using System.Text;
using MMS.LinkedList.Internal;

namespace MMS.LinkedList;

public class MLinkedList<T> : IMLinkedList<T>
{
    private MLinkedListNode<T>? _head;

    private int _count;

    public MLinkedList()
    {
    }

    public MLinkedList(T item)
    {
        Initialize(item);
    }

    private void Initialize(T item)
    {
        _head = new MLinkedListNode<T>(item);
        _head.Next = _head;
        _head.Prev = _head;
        _count++;
    }

    public event Action<T>? ItemAdded;
    public event Action<T>? ItemRemoved;
    public event Action? Cleared;

    public void Add(T item)
    {
        AddLast(item);
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
                Next = _head,
                Prev = _head.Prev
            };
            _head.Prev.Next = first;
            _head.Prev = first;
            _head = first;
            _count++;
        }
        
        ItemAdded?.Invoke(item);
    }

    public void AddLast(T item)
    {
        if (_head is null)
        {
            Initialize(item);
        }
        else
        {
            var last = new MLinkedListNode<T>(item)
            {
                Next = _head,
                Prev = _head.Prev
            };
            _head.Prev.Next = last;
            _head.Prev = last;
            _count++;
        }

        ItemAdded?.Invoke(item);
    }

    public void AddAfter(T after, T item)
    {
        var (node, _) = FindByValue(after);

        if (node is null)
            throw new ArgumentException("After item not found", nameof(after));

        InsertAfterNode(item, node);

        _count++;
        ItemAdded?.Invoke(item);
    }

    public T? GetFirst()
    {
        return _head is null ? default : _head.Item;
    }

    public T? GetLast()
    {
        return _head is null ? default : _head.Prev.Item;
    }

    public void Clear()
    {
        _head = null;
        _count = 0;

        Cleared?.Invoke();
    }

    public bool Contains(T item)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        var (node, _) = FindByValue(item);

        return node is not null;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));
        if (arrayIndex < 0)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), arrayIndex, "Index less than zero");
        if (arrayIndex > array.Length)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), arrayIndex, "Index higher than array length");
        if (array.Length - arrayIndex < _count)
            throw new ArgumentException("Insufficient space in array");

        foreach (var t in this)
        {
            array[arrayIndex++] = t;
        }
    }

    public void CopyTo(Array array, int index)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));
        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index), index, "Index less than zero");
        if (index > array.Length)
            throw new ArgumentOutOfRangeException(nameof(index), index, "Index higher than array length");
        if (array.Length - index < _count)
            throw new ArgumentException("Insufficient space in array");

        foreach (var t in this)
        {
            array.SetValue(t, index++);
        }
    }

    public bool Remove(T item)
    {
        var (node, _) = FindByValue(item);
        if (node is null)
            return false;

        RemoveNode(node);
        return true;
    }

    public void RemoveFirst()
    {
        if (_head is null)
            throw new InvalidOperationException();
        
        RemoveNode(_head);
    }

    public void RemoveLast()
    {
        if (_head is null)
            throw new InvalidOperationException();

        RemoveNode(_head.Prev);
    }

    public void RemoveAt(int index)
    {
        var node = FindByIndex(index);
        
        RemoveNode(node);
    }

    public void RemoveAfter(T after)
    {
        var (node, _) = FindByValue(after);
        if (node is null)
            throw new ArgumentException("After item not found", nameof(after));
        
        RemoveNode(node.Next);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new MLinkedListEnumerator<T>(this, _head);
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
        throw new PlatformNotSupportedException();
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        throw new PlatformNotSupportedException();
    }

    public int IndexOf(T item)
    {
        return FindByValue(item).Item2;
    }

    public void Insert(int index, T item)
    {
        var node = FindByIndex(index);
        node.Item = item;
    }

    public T this[int index]
    {
        get => FindByIndex(index).Item;
        set => Insert(index, value);
    }

    private (MLinkedListNode<T>?, int) FindByValue(T item)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        if (_head is null)
            return (null, 0);

        var current = _head;
        var idx = 0;
        do
        {
            idx++;
            if (current.Item != null && current.Item.Equals(item))
            {
                return (current, idx);
            }

            current = current.Next;
        } while (current.Next != _head);

        return (null, 0);
    }
    
    private static void InsertAfterNode(T item, MLinkedListNode<T> node)
    {
        var newNode = new MLinkedListNode<T>(item)
        {
            Prev = node,
            Next = node.Next
        };
        node.Next.Prev = newNode;
        node.Next = newNode;
    }

    private void RemoveNode(MLinkedListNode<T> node)
    {
        if (_head!.Next == _head)
        {
            _head = null;
        }
        else if (_head == node)
        {
            _head.Next.Prev = _head.Prev;
            _head.Prev.Next = _head.Next;

            _head = _head.Next;
        }
        else
        {
            node.Next.Prev = node.Prev;
            node.Prev.Next = node.Next;
        }

        ItemRemoved?.Invoke(node.Item);
        _count--;

        if (_count == 0)
            Cleared?.Invoke();
    }
    
    private MLinkedListNode<T> FindByIndex(int index)
    {
        if (index < 0 || index >= _count)
            throw new IndexOutOfRangeException();

        var current = _head;
        var idx = 0;
        do
        {
            if (++idx == index)
                return current!;
            
            current = current!.Next;
        } while (current.Next != _head);

        return null!;
    }

    public override string ToString()
    {
        var strBuilder = new StringBuilder();
        foreach (var t in this)
        {
            strBuilder.Append($"{t}->");
        }

        strBuilder.Remove(strBuilder.Length - 2, 2);
        return strBuilder.ToString();
    }
}