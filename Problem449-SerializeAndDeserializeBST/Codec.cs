public class Codec
{
    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        if (root == null) return string.Empty;

        var sb = new StringBuilder();
        var queue = new Queue<TreeNode>();
        var first = true;

        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var temp = queue.Dequeue();
            if (temp == null)
            {
                sb.Append(",X");
            }
            else
            {
                if (first)
                {
                    sb.Append(temp.val);
                }
                else
                {
                    sb.Append($",{temp.val}");
                }
                queue.Enqueue(temp.left);
                queue.Enqueue(temp.right);
                first = false;
            }
        }

        return sb.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        //DATA: 1,2,3,X,X,4,5,6,7,8,X
        if (string.IsNullOrWhiteSpace(data)) return null;
        var array = data.Split(',');
        if (array.Length == 0) return null;
        //Root will not be null
        var index = 0;
        var root = new TreeNode(int.Parse(array[index++]));
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        
        while (q.Count > 0)
        {
            //Get the next node
            var node = q.Dequeue();

            //Add children
            var tempLeft = index < array.Length ? array[index++] : null;
            var tempRight = index < array.Length ? array[index++] : null;

            //Add nodes only if they are valid values
            if (!string.IsNullOrWhiteSpace(tempLeft) && !tempLeft.Contains("X"))
            {
                var value = int.Parse(tempLeft);
                node.left = new TreeNode(value);
                q.Enqueue(node.left);
            }

            if (!string.IsNullOrWhiteSpace(tempRight) && !tempRight.Contains("X"))
            {
                var value = int.Parse(tempRight);
                node.right = new TreeNode(value);
                q.Enqueue(node.right);
            }
        }

        return root;
    }
}
