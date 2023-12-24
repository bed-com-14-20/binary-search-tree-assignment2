public class BinaryTree<T> where T : IComparable<T>
{
    private Node<T> root;

    // Insert method
    public void Insert(T data)
    {
        root = InsertRec(root, data);
    }

    // Recursive helper method for Insert
    private Node<T> InsertRec(Node<T> node, T data)
    {
        if (node == null)
            return new Node<T>(data);

        int compareResult = data.CompareTo(node.Data);
        if (compareResult < 0)
            node.Left = InsertRec(node.Left, data);
        else if (compareResult > 0)
            node.Right = InsertRec(node.Right, data);

        return node;
    }

    // Search method
    public bool Search(T data, out Node<T> foundNode, out Node<T> parentNode)
    {
        foundNode = null;
        parentNode = null;
        return SearchRec(root, data, ref foundNode, ref parentNode);
    }

    // Recursive helper method for Search
    private bool SearchRec(Node<T> node, T data, ref Node<T> foundNode, ref Node<T> parentNode)
    {
        if (node == null)
            return false;

        int compareResult = data.CompareTo(node.Data);
        if (compareResult == 0)
        {
            foundNode = node;
            return true;
        }

        parentNode = node;
        return SearchRec(compareResult < 0 ? node.Left : node.Right, data, ref foundNode, ref parentNode);
    }

    // Remove method
    public void Remove(T data)
    {
        root = RemoveRec(root, data);
    }

    // Recursive helper method for Remove
    private Node<T> RemoveRec(Node<T> node, T data)
    {
        if (node == null)
            return node;

        int compareResult = data.CompareTo(node.Data);
        if (compareResult < 0)
            node.Left = RemoveRec(node.Left, data);
        else if (compareResult > 0)
            node.Right = RemoveRec(node.Right, data);
        else
        {
            if (node.Left == null)
                return node.Right;
            else if (node.Right == null)
                return node.Left;

            node.Data = MinValue(node.Right);
            node.Right = RemoveRec(node.Right, node.Data);
        }

        return node;
    }

    // Helper method to find the minimum value in a subtree
    private T MinValue(Node<T> node)
    {
        T minValue = node.Data;
        while (node.Left != null)
        {
            minValue = node.Left.Data;
            node = node.Left;
        }
        return minValue;
    }

    // Simplified InorderTraversal method
    public void PrintInorder()
    {
        Console.Write("Inorder Traversal: ");
        InorderTraversal(root);
        Console.WriteLine();
    }

    // Recursive helper method for InorderTraversal
    private void InorderTraversal(Node<T> node)
    {
        if (node != null)
        {
            InorderTraversal(node.Left);
            Console.Write($"{node.Data} ");
            InorderTraversal(node.Right);
        }
    }

    // Simplified PostorderTraversal method
    public void PrintPostorder()
    {
        Console.Write("Postorder Traversal: ");
        PostorderTraversal(root);
        Console.WriteLine();
    }

    // Recursive helper method for PostorderTraversal
    private void PostorderTraversal(Node<T> node)
    {
        if (node != null)
        {
            PostorderTraversal(node.Left);
            PostorderTraversal(node.Right);
            Console.Write($"{node.Data} ");
        }
    }
}
