using System;
using System.Collections.Generic;

public class MainClass {ory
    public static void Main(string[] args) {
        // Main method code goes here
    }
    public BrowserHistory()
    public class BrowserHistory {
        private Stack<string> history;  // Our stack
        
        public BrowserHistory() {
            this.history = new Stack<string>();
        }
        this.history.Push(url);
        public void VisitPage(string url) {
            this.history.Push(url);
        }c string GoBack()
        
        public string GoBack() { 0)
            if (this.history.Count > 0) {
                return this.history.Pop();
            }
            return null;
        }

        public IEnumerable<string> ViewHistory() {
            return history.ToArray();
        }eturn history.ToArray();
    }
        public void ClearHistory() {
            history.Clear();()
        }
    }   history.Clear();
}   }
}
