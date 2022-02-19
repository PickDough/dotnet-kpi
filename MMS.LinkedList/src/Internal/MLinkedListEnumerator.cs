using System.Collections;
using System.Runtime.Serialization;

namespace MMS.LinkedList.Internal;

public class MLinkedListEnumerator<T> :
    IEnumerator<T>,
    ISerializable,
    IDeserializationCallback
{
    private MLinkedListNode<T> _current;
    private readonly MLinkedList<T> _list;
    private readonly MLinkedListNode<T>? _head;


    public MLinkedListEnumerator(MLinkedList<T> list, MLinkedListNode<T>? head)
    {
        _list = list;
        _head = head;
        Reset();
    }

    public bool MoveNext()
    {
        _current = _current.Next;
        
        return _current != _head;
    }

    public void Reset()
    {
        if (_head is null)
        {
            _current = _head;
            return;
        }

        _current = new MLinkedListNode<T>(default(T))
        {
            Next = new MLinkedListNode<T>(_head.Item)
            {
                Next = _head.Next
            }
        };
    }

    public T Current => _current.Item;

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        throw new PlatformNotSupportedException();
    }

    public void OnDeserialization(object? sender)
    {
        throw new PlatformNotSupportedException();
    }
}