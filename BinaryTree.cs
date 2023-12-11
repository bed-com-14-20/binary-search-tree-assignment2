 using System;

public class BinaryTree<T> where T : IComparable<T>
{
    private Node<T> root;

    public void Insert(T data)
    {
        root = InsertRec(root, data);
    }

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

    public bool Search(T data, out Node<T> foundNode, out Node<T> parentNode)
    {
        foundNode = null;
        parentNode = null;
        return SearchRec(root, data, ref foundNode, ref parentNode);
    }

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

    public void Remove(T data)
    {
        root = RemoveRec(root, data);
    }

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

    private void InorderTraversal(Node<T> node, Action<T> action)
    {
        if (node != null)
        {
            InorderTraversal(node.Left, action);
            action(node.Data);
            InorderTraversal(node.Right, action);
        }
    }

    public void PrintInorder()
    {
        Console.Write("Inorder Traversal: ");
        InorderTraversal(root, data => Console.Write($"{data} "));
        Console.WriteLine();
    }

    private void PostorderTraversal(Node<T> node, Action<T> action)
    {
        if (node != null)
        {
            PostorderTraversal(node.Left, action);
            PostorderTraversal(node.Right, action);
            action(node.Data);
        }
    }

    public void PrintPostorder()
    {
        Console.Write("Postorder Traversal: ");
        PostorderTraversal(root, data => Console.Write($"{data} "));
        Console.WriteLine();
    }
}
