import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
    public static void main(String[] args) {
        // Main method code goes here
    }
    
    public void petOwnerRelationships() {
        // Pet-Owner relationships
        Map<String, List<String>> relationships = new HashMap<>();
        // Wendesday is Keith's cat
        relationships.put("Wednesday", Arrays.asList("Keith"));     
        // Keith is Wednesday's human
        relationships.put("Keith", Arrays.asList("Wednesday"));     
        // Whiskers is Tom's cat
        relationships.put("Whiskers", Arrays.asList("Tom"));  
        // Tom is Whiskers' human
        relationships.put("Tom", Arrays.asList("Whiskers"));  
    }
}