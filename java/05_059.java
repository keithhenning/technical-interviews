import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
    public static void main(String[] args) {
        // Main method code goes here
    }
    
    public int goodHash(Object key) {
        // Use built-in hash for strings
        if (key instanceof String) {
            return key.hashCode();
        }
        // Custom hash for arrays
        if (key instanceof Object[]) {
            return Arrays.hashCode((Object[]) key);
        }
        
        return key.hashCode();
    }
}