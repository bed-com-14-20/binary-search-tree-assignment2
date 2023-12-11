 public class Node<TNodeData> where TNodeData : IComparable<TNodeData>
{
    public TNodeData Data { get; set; }
    public Node<TNodeData>? Left { get; set; }
    public Node<TNodeData>? Right { get; set; }

    public Node(TNodeData data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}
 