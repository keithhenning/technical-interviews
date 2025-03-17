import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
    public static void main(String[] args) {
        // Main method code goes here
    }
    
    public class BrowserHistory {
        private Stack<String> history;  // Our stack
        
        public BrowserHistory() {
            this.history = new Stack<>();
        }
        
        public void visitPage(String url) {
            this.history.push(url);
        }
        
        public String goBack() {
            if (!this.history.isEmpty()) {
                return this.history.pop();
            }
            return null;
        }
    }
}