using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashTables
{
    public class MyIntHashTable : IHashTable<int>
    {
        public const int size = 10;
        private List<MyLinkedList<int>> list = new List<MyLinkedList<int>>(size);

        public MyIntHashTable()
        {
            for (int i = 0; i < size; i++)
            {
                list.Add(new MyLinkedList<int>());
            }
        }
        public int Hash(int value)
        {
            return value % size;
        }

        public void Add(int value)
        {
            list[Hash(value)].Add(value);
        }

        public void Remove(int value)
        {
            list[Hash(value)].Remove(value);
        }

        public MyLinkedList<int> Find(int key)
        {
            int keyIndex = Hash(key);
            return list[keyIndex];
        }

        public int FindFirst(int key)
        {
            return Find(key).First();
        }
    }
}
