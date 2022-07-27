namespace DataStructures.HashTables
{
    public interface IHashTable<T>
    {
        public int Hash(T key);

        public void Add(T value);

        public void Remove(T value);

        public MyLinkedList<T> Find(T key);

        public T FindFirst(T key);
    }
}
