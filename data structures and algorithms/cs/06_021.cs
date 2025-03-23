public void DfsThreeWays(TreeNode node)
{
   // Base case: return if node is null
   if (node == null)
   {
      return;
   }

   // Pre-order: Process BEFORE children
   Console.WriteLine(node.Value);  // Pre-order
   DfsThreeWays(node.Left);
   // In-order: Process BETWEEN children
   Console.WriteLine(node.Value);  // In-order
   DfsThreeWays(node.Right);
   // Post-order: Process AFTER children
   Console.WriteLine(node.Value);  // Post-order
}
