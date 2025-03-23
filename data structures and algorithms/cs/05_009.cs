using System;
using System.Collections.Generic;

public class MainClass {
   public static void Main(string[] args) {
      // Main method code goes here
   }
   
   public class BrowserHistory {
      // Our stack
      private Stack<string> history;
      
      public BrowserHistory() {
         this.history = new Stack<string>();
      }
      
      public void VisitPage(string url) {
         this.history.Push(url);
      }
      
      public string GoBack() {
         if (this.history.Count > 0) {
            return this.history.Pop();
         }
         return null;
      }
   }
}