using System.Collections;
using System.Runtime.Serialization;
using MMS.LinkedList.Abstract;

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
        if (_current.Next == _head)
            return false;

        _current = _current.Next;

        return true;
    }

    public void Reset()
    {
        _current = new MLinkedListNode<T>(default(T))
        {
            Next = _head
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