using System;
using System.Collections.Generic;

class ClothingItem
{
   public string Type { get; }
   public int Popularity { get; }

   public ClothingItem(string type, int popularity)
   {
      Type = type;
      Popularity = popularity;
   }
}

public class FashionStack
{
   private Stack<ClothingItem> mainStack;
   private Stack<ClothingItem> tempStack;

   public FashionStack()
   {
      mainStack = new Stack<ClothingItem>();
      tempStack = new Stack<ClothingItem>();
   }

   public void AddItem(string type, int popularity)
   {
      mainStack.Push(new ClothingItem(type, popularity));
   }

   public ClothingItem RemoveTopItem()
   {
      if (mainStack.Count == 0)
      {
         return null;
      }
      return mainStack.Pop();
   }

   public ClothingItem FindAndRemoveType(string targetType)
   {
      if (mainStack.Count == 0)
      {
         return null;
      }

      ClothingItem mostPopular = null;
      int mostPopularIndex = -1;

      for (int i = mainStack.Count - 1; i >= 0; i--)
      {
         ClothingItem item = mainStack.ToArray()[i];
         if (item.Type == targetType)
         {
            if (mostPopular == null ||
               item.Popularity > mostPopular.Popularity)
            {
               mostPopular = item;
               mostPopularIndex = i;
            }
         }
      }

      if (mostPopularIndex == -1)
      {
         return null;
      }

      int itemsToMove =
         mainStack.Count - mostPopularIndex - 1;
      for (int i = 0; i < itemsToMove; i++)
      {
         tempStack.Push(mainStack.Pop());
      }

      ClothingItem result = mainStack.Pop();

      while (tempStack.Count > 0)
      {
         mainStack.Push(tempStack.Pop());
      }

      return result;
   }

   public void ReorganizeByPopularity()
   {
      if (mainStack.Count == 0)
      {
         return;
      }

      while (mainStack.Count > 0)
      {
         tempStack.Push(mainStack.Pop());
      }

      List<ClothingItem> sortedItems =
         new List<ClothingItem>(tempStack);
      sortedItems.Sort((a, b) =>
         b.Popularity.CompareTo(a.Popularity));
      tempStack.Clear();

      foreach (ClothingItem item in sortedItems)
      {
         mainStack.Push(item);
      }
   }
}
