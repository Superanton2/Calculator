namespace CS201;

public class TreeNode
{
    public string Value { get; }
    public MyList<TreeNode> Children { get; }

    public TreeNode(string value)
    {
        Value = value;
        Children = new MyList<TreeNode>();
    }
}