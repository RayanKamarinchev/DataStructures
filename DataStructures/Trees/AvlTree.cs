namespace DataStructures.Trees
{
    public class AvlTree
    {
        public class Node
        {
            public int data;
            public Node left { get; set; }
            public Node right { get; set; }

            public Node(int data)
            {
                this.data = data;
            }
        }

        private Node root;

        public AvlTree()
        {
        }

        public void Add(int value)
        {
            Node node = new Node(value);
            if (root == null)
            {
                root = node;
            }
            else
            {
                root = RecursiveInsert(root, node);
            }
        }

        private Node RecursiveInsert(Node? startNode, Node node)
        {
            if (startNode == null)
            {
                startNode = node;
                return startNode;
            }
            if (node.data > startNode.data)
            {
                RecursiveInsert(startNode.right, node);
                startNode = BalanceTree(startNode);
            }
            else
            {
                RecursiveInsert(startNode.left, node);
            }

            return startNode;
        }

        private Node BalanceTree(Node node)
        {
            int balanceFactor = BalanceFactor(node);
            //Left
            if (balanceFactor > 1)
            {
                //Left
                if (BalanceFactor(node.left) > 0)
                {
                    node = RotateLL(node);
                }
                //Right
                else
                {
                    node = RotateLR(node);
                }
            }
            //Right
            else if (balanceFactor < -1)
            {
                //Left
                if (BalanceFactor(node.right) > 0)
                {
                    node = RotateRL(node);
                }
                //Right
                else
                {
                    node = RotateRR(node);
                }
            }
            return node;
        }

        private Node RotateLR(Node node)
        {
            Node pivot = node.left;
            node.left = RotateRR(pivot);
            return RotateLL(node);
        }

        private Node RotateRL(Node node)
        {
            Node pivot = node.right;
            node.right = RotateLL(pivot);
            return RotateRR(node);
        }

        private Node RotateRR(Node node)
        {
            Node child = node.right;
            node.right = child.left;
            child.left = node;
            return child;
        }

        private Node RotateLL(Node node)
        {
            Node child = node.left;
            node.left = child.right;
            child.right = node;
            return child;
        }

        private int BalanceFactor(Node node)
        {
            int l = GetHight(node.left);
            int r = GetHight(node.right);
            return l - r;
        }

        private int GetHight(Node node)
        {
            int hight = 0;
            if (node != null)
            {
                int l = GetHight(node.left);
                int r = GetHight(node.right);
                int m = Math.Max(l, r);
                hight = m + 1;
            }
            return hight;
        }
    }
}
