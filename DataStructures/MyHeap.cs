using System.Collections;

namespace DataStructures
{
    public class MyHeap
    {
        private const int InitialCapacity = 0;
        private int capacity = InitialCapacity;
        private int?[] array = new int?[InitialCapacity];

        public int Count => array.Count(x => x != null);
        public int Capacity => capacity;

        public int? this[int index] => array[index];
        public void Add(int num)
        {
            if (Count == Capacity)
                Grow();

            array[Count] = num;
            BubbleUp(Count-1);
        }

        public void Poll()
        {
            (array[0], array[Count-1]) = (array[Count-1], array[0]);
            array[Count - 1] = null;
            BubbleDown(0);
        }

        public void Remove(int num)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i] == num)
                {
                    (array[i], array[Count - 1]) = (array[Count - 1], array[i]);
                    array[Count-1]=null;
                    BubbleUp(i);
                    BubbleDown(i);
                }
            }
        }

        private void BubbleUp(int index)
        {
            if (index==0)
            {
                return;
            }
            int parentIndex = (index % 2 == 0 ? index - 2 : index - 1) / 2;
            while (array[parentIndex] > array[index])
            {
                (array[parentIndex], array[index]) = (array[index], array[parentIndex]);
                index = parentIndex;
                parentIndex = (index % 2 == 0 ? index - 2 : index - 1) / 2;
            }
        }

        private void BubbleDown(int index)
        {
            if (index * 2 > Count)
            {
                return;
            }
            int childIndex = (array[index * 2 + 1] > array[index * 2 + 2] ? index * 2 + 2 : index * 2 + 1);
            while (array[childIndex] < array[index])
            {
                (array[childIndex], array[index]) = (array[index], array[childIndex]);
                index = childIndex;
                if (index*2>Count)
                {
                    return;
                }
                childIndex = (array[index * 2 + 1] > array[index * 2 + 2] ? index * 2 + 2 : index * 2 + 1);
            }
        }

        private void Grow()
        {
            int?[] array1 = array;
            capacity = (capacity == 0 ? 1 : capacity * 2);
            array = new int?[capacity];
            for (int i = 0; i < array1.Length; i++)
            {
                array[i] = array1[i];
            }
        }
    }
}