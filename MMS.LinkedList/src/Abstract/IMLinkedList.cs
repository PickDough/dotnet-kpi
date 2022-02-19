using System.Collections;
using System.Runtime.Serialization;

namespace MMS.LinkedList.Abstract;

public interface IMLinkedList<T> :
    ICollection<T>,
    IReadOnlyCollection<T>,
    ICollection,
    IDeserializationCallback,
    ISerializable,
    IList<T>
{
    event Action<T> ItemAdded;
    event Action<T> ItemRemoved;
    event Action Cleared;

    void AddFirst(T item);
    void AddLast(T item);
    void AddAfter(T after, T item);
    
    T? GetFirst();
    T? GetLast();

    void RemoveFirst();
    void RemoveLast();
    void RemoveAfter(T after);
}