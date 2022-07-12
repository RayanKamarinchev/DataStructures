using System.Collections;

namespace DataStructures
{
    public class MyPriorityQueue<T> : IEnumerable<T>
    {
        private int heapSize = 0;
        private int heapCapacity = 0;
        private List<T> heap = null;

        public MyPriorityQueue(int size)
        {
            heap = new List<T>(size);
        }

        public MyPriorityQueue(T[] elements)
        {
            heapSize = elements.Length;
            heapCapacity = elements.Length;
            foreach (var element in elements)
            {
                heap.Add(element);
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
