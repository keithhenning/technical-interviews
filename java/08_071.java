import java.util.*;

class ClothingItem {
   String type;
   int popularity;
   
   public ClothingItem(String type, int popularity) {
      this.type = type;
      this.popularity = popularity;
   }
}

public class FashionStack {
   private Stack<ClothingItem> mainStack;
   private Stack<ClothingItem> tempStack;
   
   public FashionStack() {
      mainStack = new Stack<>();
      tempStack = new Stack<>();
   }
   
   public void addItem(String type, int popularity) {
      mainStack.push(new ClothingItem(type, popularity));
   }
   
   public ClothingItem removeTopItem() {
      if (mainStack.isEmpty()) {
         return null;
      }
      return mainStack.pop();
   }
   
   public ClothingItem findAndRemoveType(String targetType) {
      if (mainStack.isEmpty()) {
         return null;
      }
      
      // Find most popular target type item
      ClothingItem mostPopular = null;
      int mostPopularIndex = -1;
      
      for (int i = mainStack.size() - 1; i >= 0; i--) {
         ClothingItem item = mainStack.get(i);
         if (item.type.equals(targetType)) {
            if (mostPopular == null || 
                  item.popularity > mostPopular.popularity) {
               mostPopular = item;
               mostPopularIndex = i;
            }
         }
      }
      
      if (mostPopularIndex == -1) {
         return null;
      }
      
      // Move items before target to temp stack
      int itemsToMove = mainStack.size() - mostPopularIndex - 1;
      for (int i = 0; i < itemsToMove; i++) {
         tempStack.push(mainStack.pop());
      }
      
      // Remove target item
      ClothingItem result = mainStack.pop();
      
      // Restore items from temp stack
      while (!tempStack.isEmpty()) {
         mainStack.push(tempStack.pop());
      }
      
      return result;
   }
   
   public void reorganizeByPopularity() {
      if (mainStack.isEmpty()) {
         return;
      }
      
      // Move all items to temp stack
      while (!mainStack.isEmpty()) {
         tempStack.push(mainStack.pop());
      }
      
      // Sort items by popularity
      List<ClothingItem> sortedItems = 
            new ArrayList<>(tempStack);
      sortedItems.sort((a, b) -> 
            Integer.compare(b.popularity, a.popularity));
      tempStack.clear();
      
      // Restore sorted items to main stack
      for (ClothingItem item : sortedItems) {
         mainStack.push(item);
      }
   }
}