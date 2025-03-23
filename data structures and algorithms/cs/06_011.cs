public List<List<int>> LevelOrder(TreeNode root)
{
   if (root == null)
   {
      return new List<List<int>>();
   }

   List<List<int>> result = new List<List<int>>();
   Queue<TreeNode> queue = new Queue<TreeNode>();
   queue.Enqueue(root);

   while (queue.Count > 0)
   {
      List<int> level = new List<int>();
      int levelSize = queue.Count;

      for (int i = 0; i < levelSize; i++)
      {
         TreeNode node = queue.Dequeue();
         level.Add(node.Value);

         if (node.Left != null)
         {
            queue.Enqueue(node.Left);
         }
         if (node.Right != null)
         {
            queue.Enqueue(node.Right);
         }
      }

      result.Add(level);
   }

   return result;
}
