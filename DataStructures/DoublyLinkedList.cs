using System.Collections;

namespace DataStructures
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public class Node
        {
            public Node Next { get; set; }
            public Node Prev { get; set; }
            public T Data { get; set; }
        }

        private Node root = null;
        public Node First => null;

        public Node Last
        {
            get
            {
                Node curr = root;
                if (curr == null)
                    return null;
                while (curr.Next != null)
                {
                    curr = curr.Next;
                }

                return curr;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new List<T>.Enumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
