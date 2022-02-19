// See https://aka.ms/new-console-template for more information

using MMS.LinkedList;

AddExample();
RemoveExample();

void AddExample()
{
    Console.WriteLine("Add example");
    var ll = new MLinkedList<int>();
    ll.ItemAdded += i => Console.WriteLine($"{i} was added");
    
    ll.AddFirst(1);
    Console.WriteLine(ll);
    ll.AddLast(3);
    Console.WriteLine(ll);
    ll.AddAfter(1, 2);
    Console.WriteLine(ll);
    ll.AddFirst(0);
    Console.WriteLine(ll);
    ll.AddLast(4);
    Console.WriteLine(ll);
}

void RemoveExample() {
    Console.WriteLine("Remove example");
    var ll = new MLinkedList<int>();
    ll.ItemRemoved += i => Console.WriteLine($"{i} was removed");
    ll.Cleared += () => Console.WriteLine($"Collection is empty");
    
    ll.AddFirst(1);
    ll.AddLast(3);
    ll.AddAfter(1, 2);
    ll.AddFirst(0);
    ll.AddLast(4);
    
    Console.WriteLine(ll);
    
    ll.RemoveLast();
    Console.WriteLine(ll);
    ll.RemoveFirst();
    Console.WriteLine(ll);
    ll.RemoveAfter(1);
    Console.WriteLine(ll);
    ll.Clear();
    Console.WriteLine();
}