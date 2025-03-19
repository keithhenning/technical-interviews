using System;

public class Node
{
    public int Key { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(int key)
    {
        this.Key = key;
    }
}

public class BST
{
    public Node SortedArrayToBST(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return null;
        }
        return SortedArrayToBSTHelper(nums, 0, nums.Length - 1);
    }

    private Node SortedArrayToBSTHelper(int[] nums, int start, int end)
    {
        if (start > end)
        {
            return null;
        }

        int mid = start + (end - start) / 2;
        Node node = new Node(nums[mid]);
        node.Left = SortedArrayToBSTHelper(nums, start, mid - 1);
        node.Right = SortedArrayToBSTHelper(nums, mid + 1, end);
        return node;
    }
}
