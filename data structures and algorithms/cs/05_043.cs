using System;
using System.Collections.Generic;
using System.Linq;

public class FileSystemNode
{
   private string name;
   private bool isDirectory;
   private List<FileSystemNode> children;

   public FileSystemNode(string name, bool isDirectory)
   {
      this.name = name;
      this.isDirectory = isDirectory;
      this.children = isDirectory ? new List<FileSystemNode>() : null;
   }

   public void AddChild(FileSystemNode child)
   {
      if (this.isDirectory)
      {
         this.children.Add(child);
      }
   }

   public void PrintStructure(int level)
   {
      string indent = new string(' ', level * 2);
      Console.WriteLine($"{indent}{this.name}/");
      if (this.isDirectory)
      {
         foreach (FileSystemNode child in this.children)
         {
            child.PrintStructure(level + 1);
         }
      }
   }

   public string Name => name;
   public bool IsDirectory => isDirectory;
   public IReadOnlyList<FileSystemNode> Children =>
      isDirectory ? children.AsReadOnly() : null;

   public int GetSize()
   {
      if (!isDirectory) return 1;
      return children.Sum(child => child.GetSize());
   }
}
