import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
    public static void main(String[] args) {
        // Main method code goes here
    }
    
    public class FileSystemNode {
        private String name;
        private boolean isDirectory;
        private List<FileSystemNode> children;
        
        public FileSystemNode(String name, boolean isDirectory) {
            this.name = name;
            this.isDirectory = isDirectory;
            this.children = isDirectory ? new ArrayList<>() : null;
        }
            
        public void addChild(FileSystemNode child) {
            if (this.isDirectory) {
                this.children.add(child);
            }
        }
            
        public void printStructure(int level) {
            String indent = "  ".repeat(level);
            System.out.println(indent + this.name + "/");
            if (this.isDirectory) {
                for (FileSystemNode child : this.children) {
                    child.printStructure(level + 1);
                }
            }
        }
    }
}