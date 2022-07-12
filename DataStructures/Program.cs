using DataStructures;

MyHeap heap = new MyHeap();
heap.Add(1);
heap.Add(5);
heap.Add(1);
heap.Add(8);
heap.Add(6);
heap.Add(2);
heap.Add(2);
heap.Add(13);
heap.Add(12);
heap.Add(11);
heap.Add(7);
heap.Add(2);
heap.Add(15);
heap.Add(3);
heap.Add(10);

heap.Poll();
Print();
heap.Remove(12);
Print();
heap.Remove(3);
Print();
heap.Poll();
Print();
heap.Remove(6);
Print();

bool IsPowerOfTwo(int x)
{
    return (x & (x - 1)) == 0;
}

void Print()
{
    for (int i = 0; i < heap.Count; i++)
    {
        Console.Write(heap[i] + " ");
        if (IsPowerOfTwo(i + 2))
        {
            Console.WriteLine();
        }
    }

    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
}