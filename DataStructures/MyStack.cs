using System.Collections;

namespace DataStructures
{
    public class MyStack<T> : IEnumerable<T>
    {
        MyLinkedList<T> list = new MyLinkedList<T>();

        public void Push(T value)
        {
            list.Add(value);
        }

        public T Pop()
        {
            list.RemoveAt(list.Count-1);
            return Peek();
        }

        public T Peek()
        {
            if (list.First==null)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return list.First.Data;
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
