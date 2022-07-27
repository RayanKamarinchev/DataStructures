using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashTables
{
    internal class MyStringHashTable : IHashTable<string>
    {
        public const int size = 20;
        private List<MyLinkedList<string>> list = new List<MyLinkedList<string>>(size);
        public int Hash(string key)
        {
            return key.Length % size;
        }

        public void Add(string value)
        {
            list[Hash(value)].Add(value);
        }

        public void Remove(string value)
        {
            list[Hash(value)].Remove(value);
        }

        public MyLinkedList<string> Find(string key)
        {
            int keyIndex = Hash(key);
            return list[keyIndex];
        }

        public string FindFirst(string key)
        {
            return Find(key).First();
        }
    }
}
