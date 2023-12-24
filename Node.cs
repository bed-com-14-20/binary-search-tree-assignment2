 public class Node<T>
{
    public T Data { get; set; }
    public Node<T>? Left { get; set; }
    public Node<T>? Right { get; set; }

    // Constructor
    public Node(T data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}
