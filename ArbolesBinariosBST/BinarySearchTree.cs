namespace ArbolesBinariosBST
{
    public class BinarySearchTree
    {
        public Node? Root { get; private set; }

        public void Insert(int value)
        {
            Root = InsertRecursive(Root, value);
        }

        private Node InsertRecursive(Node? current, int value)
        {
            if (current == null)
            {
                return new Node(value);
            }

            if (value < current.Value)
            {
                current.Left = InsertRecursive(current.Left, value);
            }
            else if (value > current.Value)
            {
                current.Right = InsertRecursive(current.Right, value);
            }

            return current;
        }

        public void InOrder()
        {
            InOrderRecursive(Root);
            Console.WriteLine();
        }

        private void InOrderRecursive(Node? current)
        {
            if (current != null)
            {
                InOrderRecursive(current.Left);
                Console.Write(current.Value + " ");
                InOrderRecursive(current.Right);
            }
        }

        public void PreOrder()
        {
            PreOrderRecursive(Root);
            Console.WriteLine();
        }

        private void PreOrderRecursive(Node? current)
        {
            if (current != null)
            {
                Console.Write(current.Value + " ");
                PreOrderRecursive(current.Left);
                PreOrderRecursive(current.Right);
            }
        }

        public void PostOrder()
        {
            PostOrderRecursive(Root);
            Console.WriteLine();
        }

        private void PostOrderRecursive(Node? current)
        {
            if (current != null)
            {
                PostOrderRecursive(current.Left);
                PostOrderRecursive(current.Right);
                Console.Write(current.Value + " ");
            }
        }

        public bool Search(int value)
        {
            return SearchRecursive(Root, value);
        }

        private bool SearchRecursive(Node? current, int value)
        {
            if (current == null)
            {
                return false;
            }

            if (value == current.Value)
            {
                return true;
            }

            if (value < current.Value)
            {
                return SearchRecursive(current.Left, value);
            }

            return SearchRecursive(current.Right, value);
        }

        public int? FindMin()
        {
            if (Root == null)
            {
                return null;
            }

            Node current = Root;

            while (current.Left != null)
            {
                current = current.Left;
            }

            return current.Value;
        }

        public int? FindMax()
        {
            if (Root == null)
            {
                return null;
            }

            Node current = Root;

            while (current.Right != null)
            {
                current = current.Right;
            }

            return current.Value;
        }
        public int GetHeight()
{
    return GetHeightRecursive(Root);
}

private int GetHeightRecursive(Node? current)
{
    if (current == null)
    {
        return 0;
    }

    int leftHeight = GetHeightRecursive(current.Left);
    int rightHeight = GetHeightRecursive(current.Right);

    return 1 + Math.Max(leftHeight, rightHeight);
}

public int CountNodes()
{
    return CountNodesRecursive(Root);
}

private int CountNodesRecursive(Node? current)
{
    if (current == null)
    {
        return 0;
    }

    return 1 + CountNodesRecursive(current.Left)
             + CountNodesRecursive(current.Right);
}

public int CountLeaves()
{
    return CountLeavesRecursive(Root);
}

private int CountLeavesRecursive(Node? current)
{
    if (current == null)
    {
        return 0;
    }

    if (current.Left == null && current.Right == null)
    {
        return 1;
    }

    return CountLeavesRecursive(current.Left)
           + CountLeavesRecursive(current.Right);
}
public void DisplayTree()
{
    if (Root == null)
    {
        Console.WriteLine("El árbol está vacío.");
        return;
    }

    DisplayTreeRecursive(Root, "", true);
}

private void DisplayTreeRecursive(Node? current, string indent, bool isLast)
{
    if (current == null)
    {
        return;
    }

    Console.Write(indent);

    if (isLast)
    {
        Console.Write("└── ");
        indent += "    ";
    }
    else
    {
        Console.Write("├── ");
        indent += "│   ";
    }

    Console.WriteLine(current.Value);

    if (current.Left != null || current.Right != null)
    {
        if (current.Left != null)
        {
            DisplayTreeRecursive(
                current.Left,
                indent,
                current.Right == null
            );
        }

        if (current.Right != null)
        {
            DisplayTreeRecursive(
                current.Right,
                indent,
                true
            );
        }
    }
}
    }
}