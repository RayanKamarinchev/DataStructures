using System.Collections;

namespace DataStructures
{
    public class MyQueue<T> : IEnumerable<T>
    {
        private MyLinkedList<T> list;

        public void Enqueue(T value)
        {
            list.Add(value);
        }

        public T Dequeue()
        {
            list.RemoveAt(0);
            return Peek();
        }

        public T Peek()
        {
            return list.Last.Data;
        }

        public int Count => list.Count;

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