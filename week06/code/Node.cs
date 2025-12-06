public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    /// <summary>
    /// Inserts a value into the tree, ensuring only unique values are added
    /// </summary>
    public void Insert(int value)
    {
        // Only insert if value is not equal to current node (unique values)
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value); // Recursive call on left subtree
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value); // Recursive call on right subtree
        }
        // If value == Data, do nothing (skip duplicates)
    }

    /// <summary>
    /// Checks whether a given value exists in the subtree
    /// </summary>
    public bool Contains(int value)
    {
        if (value == Data)
            return true; // Found value at current node
        else if (value < Data)
            return Left != null && Left.Contains(value); // Recursive left
        else
            return Right != null && Right.Contains(value); // Recursive right
    }

    /// <summary>
    /// Returns the height of the subtree rooted at this node
    /// </summary>
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;   // Height of left subtree or 0
        int rightHeight = Right?.GetHeight() ?? 0; // Height of right subtree or 0
        return 1 + Math.Max(leftHeight, rightHeight); // 1 for current node + max of subtrees
    }
}
