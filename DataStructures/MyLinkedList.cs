using System.Collections;

namespace DataStructures
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        public class Node
        {
            public Node Next { get; set; }
            public T Data { get; set; }
        }

        private Node root = null;
        public Node First => root;

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

        public int Count
        {
            get
            {
                int n = 0;
                Node target = root;
                while (target != null)
                {
                    n++;
                    target = target.Next;
                }

                return n;
            }
        }

        public T this[int index] => GetAtIndex(index);

        public void Add(T value)
        {
            Node n = new Node() { Data = value };
            if (root == null)
                root = n;
            else
                Last.Next = n;
        }

        private void Delete(Node node)
        {
            if (root == node)
            {
                root = node.Next;
                node.Next = null;
            }
            else
            {
                Node target = root;
                while (target.Next != null)
                {
                    if (target.Next == node)
                    {
                        target.Next = node.Next;
                        node.Next = null;
                        break;
                    }

                    target = target.Next;
                }
            }
        }

        public void Remove(T obj)
        {
            RemoveAt(IndexOf(obj));
        }

        public void RemoveAt(int index)
        {
            Node target = root;
            int n = 0;
            bool isFound = false;
            while (target != null)
            {
                if (n == index)
                {
                    Delete(target);
                    isFound = true;
                    break;
                }

                target = target.Next;
                n++;
            }

            if (!isFound)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int IndexOf(T obj)
        {
            if (root == null)
            {
                throw new IndexOutOfRangeException();
            }

            int n = 0;
            Node target = root;
            while (target != null)
            {
                if (EqualityComparer<T>.Default.Equals(target.Data, obj))
                    return n;
                n++;
            }
            return -1;
        }

        public void Clear()
        {
            root = null;
        }


        public T GetAtIndex(int index)
        {
            Node target = root;
            int n = 0;
            while (n!=index||target==null)
            {
                target = target.Next;
                n++;
            }

            if (target==null)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return target.Data;
            }

        }

        public void Swap(int x, int y)
        {
            Node target = root;
            int n = -1;
            while (n != x)
            {
                target = target.Next;
                n++;
            }
            Node target2 = root;
            int m = -1;
            while (m != y)
            {
                target2 = target2.Next;
                m++;
            }

            (target.Next, target2.Next) = (target2.Next, target.Next);
        }
        //foreach
        //to array

        public IEnumerator<T> GetEnumerator()
        {
            return new List<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}