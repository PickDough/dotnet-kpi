namespace MMS.LinkedList.Internal;

public class MLinkedListNode<T>
{
    internal MLinkedListNode<T> Next;
    internal MLinkedListNode<T> Prev;

    internal T Item;

    public MLinkedListNode(T item)
    {
        Item = item;
    }
}