namespace DataStructures.Trees
{
    public class BinaryTree
    {
        public class Node
        {
            public int Data { get; set; }
            public Node? Left { get; set; } = null;
            public Node? Right { get; set; } = null;

            public Node(int data)
            {
                Data = data;
            }
        }

        private Node? root = null;

        public void Insert(int num)
        {
            if (root == null)
            {
                root = new Node(num);
                return;
            }

            Node? target = root;
            Node? oldTarget = target;
            while (target != null)
            {
                oldTarget = target;
                int result = Compare(target, num);
                if (result == 1)
                {
                    target = target.Right;
                }
                else if (result == -1)
                {
                    target = target.Left;
                }
            }

            int lastResult = Compare(oldTarget, num);
            if (lastResult == 1)
            {
                oldTarget.Right = new Node(num);
            }
            else if (lastResult == -1)
            {
                oldTarget.Left = new Node(num);
            }
        }

        public Node[] Find(int num)
        {
            if (root == null)
            {
                throw new InvalidOperationException();
            }

            Node? target = root;
            Node? oldTarget = target;
            while (target != null)
            {
                int result = Compare(target, num);
                if (result == 1)
                {
                    oldTarget = target;
                    target = target.Right;
                }
                else if (result == -1)
                {
                    oldTarget = target;
                    target = target.Left;
                }
                else
                {
                    return new Node[2] { oldTarget, target };
                }
            }
            throw new InvalidOperationException();
        }

        public void Remove(int num)
        {
            Node[] nodes = Find(num);
            Node parentTarget = nodes[0];
            Node target = nodes[1];
            bool isLeft = parentTarget.Left == target;
            if (target.Right == null && target.Left == null)
            {
                if (isLeft)
                {
                    parentTarget.Left = null;
                }
                else
                {
                    parentTarget.Right = null;
                }
                return;
            }

            if (target.Right == null)
            {
                if (isLeft)
                {
                    parentTarget.Left = target.Left;
                }
                else
                {
                    parentTarget.Right = target.Left;
                }
                return;
            }

            if (target.Left == null)
            {
                if (isLeft)
                {
                    parentTarget.Left = target.Right;
                }
                else
                {
                    parentTarget.Right = target.Right;
                }
                return;
            }

            Node? clonetarget = target.Right;
            Node? clonetargetParent = target;
            while (clonetarget.Left != null)
            {
                clonetargetParent = clonetarget;
                clonetarget = clonetarget.Left;
            }

            target.Data = clonetarget.Data;
            clonetargetParent.Right = clonetarget.Right;
        }

        private int Compare(Node target, int value)
        {
            if (target.Data > value)
            {
                return -1;
            }
            if (target.Data < value)
            {
                return 1;
            }
            return 0;
        }
    }
}