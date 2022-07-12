using DataStructures;

MyLinkedList<int> list = new MyLinkedList<int>();
list.Add(0);
list.Add(35);
Console.WriteLine(list.IndexOf(0));
list.RemoveAt(1);
Console.WriteLine(list.Count);
list.Add(69);
list.Remove(0);
Console.WriteLine(list.GetAtIndex(0));