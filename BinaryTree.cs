public class BinaryTree<T> where T : IComparable<T>
{
    private Node<T> root;

    // Insert method
     public void Insert(T data)
    {
        root = Insert_Operation(root, data);
    }

    // method for Insert with age-based sorting
    private Node<T> Insert_Operation(Node<T> node, T data)
    {
        if (node == null)
            return new Node<T>(data);

        int Result = data.CompareTo(node.Data);
        if (Result < 0)
            node.Left = Insert_Operation(node.Left, data);
        else if (Result > 0)
            node.Right = Insert_Operation(node.Right, data);

        return node;
    }

    // Search method with age-based sorting
    public bool Search(T data, out Node<T> foundNode, out Node<T> parentNode)
    {
        foundNode = null;
        parentNode = null;
        return Search_Operation(root, data, ref foundNode, ref parentNode);
    }

    // helper method for Search with age-based sorting
    private bool Search_Operation(Node<T> node, T data, ref Node<T> foundNode, ref Node<T> parentNode)
    {
        if (node == null)
            return false;

        int Result = data.CompareTo(node.Data);
        if (Result == 0)
        {
            foundNode = node;
            return true;
        }

        parentNode = node;
        return Search_Operation(Result < 0 ? node.Left : node.Right, data, ref foundNode, ref parentNode);
    }

    // Remove method with age-based sorting
    public void Remove(T data)
    {
        root = Remove_Operation(root, data);
    }

    // helper method for Remove with age-based sorting
    private Node<T> Remove_Operation(Node<T> node, T data)
    {
        if (node == null)
            return node;

        int compareResult = data.CompareTo(node.Data);
        if (compareResult < 0)
            node.Left = Remove_Operation(node.Left, data);
        else if (compareResult > 0)
            node.Right = Remove_Operation(node.Right, data);
        else
        {
            if (node.Left == null)
                return node.Right;
            else if (node.Right == null)
                return node.Left;

            node.Data = Minimum_Value(node.Right);
            node.Right = Remove_Operation(node.Right, node.Data);
        }

        return node;
    }

    // Helper method to find the minimum value in a subtree
    private T Minimum_Value(Node<T> node)
    {
        T minValue = node.Data;
        while (node.Left != null)
        {
            minValue = node.Left.Data;
            node = node.Left;
        }
        return minValue;
    }

    //  InorderTraversal method
    public void PrintInorder()
    {
        Console.Write("Inorder Traversal: ");
        InorderTraversal(root);
        Console.WriteLine();
    }

    // helper method for InorderTraversal
    // visit left child, root and right child
    private void InorderTraversal(Node<T> node)
    {
        if (node != null)
        {
            InorderTraversal(node.Left);
            Console.Write($"{node.Data} ");
            InorderTraversal(node.Right);
        }
    }
    //PostorderTraversal method
    public void PrintPostorder()
    {
        Console.Write("Postorder Traversal: ");
        PostorderTraversal(root);
        Console.WriteLine();
    }

    // helper method for PostorderTraversal
    //vist left, right child and root
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
