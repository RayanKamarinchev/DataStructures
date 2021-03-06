using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class BinaryIndexedTree
    {
        // Max tree size 
        readonly static int MAX = 1000;

        static int[] BITree = new int[MAX];

        public BinaryIndexedTree(int[] arr, int n)
        {
            constructBITree(arr, n);
        }
        int getSum(int index)
        {
            int sum = 0; // Initialize result 

            // index in BITree[] is 1 more than 
            // the index in arr[] 
            index = index + 1;

            // Traverse ancestors of BITree[index] 
            while (index > 0)
            {
                // Add current element of BITree 
                // to sum 
                sum += BITree[index];

                // Move index to parent node in 
                // getSum View 
                index -= index & -index;
            }

            return sum;
        }

        // Updates a node in Binary Index Tree (BITree) 
        // at given index in BITree. The given value 
        // 'val' is added to BITree[i] and all of 
        // its ancestors in tree. 
        public static void updateBIT(int n, int index,
                                     int val)
        {
            // index in BITree[] is 1 more than 
            // the index in arr[] 
            index = index + 1;

            // Traverse all ancestors and add 'val' 
            while (index <= n)
            {
                // Add 'val' to current node of BIT Tree 
                BITree[index] += val;

                // Update index to that of parent 
                // in update View 
                index += index & -index;
            }
        }

        /* Function to construct fenwick tree 
        from given array.*/
        void constructBITree(int[] arr, int n)
        {
            // Initialize BITree[] as 0 
            for (int i = 1; i <= n; i++)
                BITree[i] = 0;

            // Store the actual values in BITree[] 
            // using update() 
            for (int i = 0; i < n; i++)
                updateBIT(n, i, arr[i]);
        }
    }
}