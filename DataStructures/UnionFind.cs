using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class UnionFind
    {
        private int[] id;
        private int[] sz;
        private int cnt;
        private int numComponents;

        public UnionFind(int n)
        {
            cnt = n;
            id = new int[n];
            sz = new int[n];
            for (int i = 0; i < n; i++)
            {
                id[i] = i;
                sz[i] = i;
            }
        }

        public int Find(int p)
        {
            int root = p;
            while (root != id[root])
                root = id[root];

            while (p != root)
            {
                int newp = id[p];
                id[p] = root;
                p = newp;
            }

            return root;
        }

        public void Merge(int x, int y)
        {
            int i = Find(x);
            int j = Find(y);
            if (i == j) return;

            if (sz[i] < sz[j])
            {
                id[i] = j;
                sz[j] += sz[i];
            }
            else
            {
                id[j] = i;
                sz[i] += sz[j];
            }

            cnt--;
        }

        public bool Connected(int x, int y)
        {
            return Find(x) == Find(y);
        }

        public int Count() => cnt;
    }
}
