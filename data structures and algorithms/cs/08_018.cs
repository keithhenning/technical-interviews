using System;
using System.Collections.Generic;

class Node {
    public int Position { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    public int Height { get; set; }

    public Node(int position) {
        Position = position;
        Height = 1;
    }
}

public class TextEditor {
    private StringBuilder text;
    private Node root;

    public TextEditor() {
        text = new StringBuilder();
        root = null;
    }

    public void Insert(int position, string str) {
        if (position < 0 || position > text.Length) {
            throw new ArgumentException("Invalid position");
        }

        text.Insert(position, str);

        var newLinePositions = new List<int>();
        for (int i = 0; i < str.Length; i++) {
            if (str[i] == '\n') {
                newLinePositions.Add(position + i);
            }
        }

        UpdatePositions(root, position, str.Length);

        foreach (var linePos in newLinePositions) {
            root = InsertNode(root, linePos);
        }
    }

    public void Delete(int position, int length) {
        if (position < 0 || position + length > text.Length) {
            throw new ArgumentException("Invalid position or length");
        }

        var deletedText = text.ToString(position, length);
        var deletedLines = new List<int>();
        for (int i = 0; i < deletedText.Length; i++) {
            if (deletedText[i] == '\n') {
                deletedLines.Add(position + i);
            }
        }

        text.Remove(position, length);

        foreach (var linePos in deletedLines) {
            root = DeleteNode(root, linePos);
        }

        UpdatePositions(root, position, -length);
    }

    public int GetLineNumber(int position) {
        if (position < 0 || position > text.Length) {
            throw new ArgumentException("Invalid position");
        }

        return CountSmaller(root, position);
    }

    private int GetHeight(Node node) {
        return node == null ? 0 : node.Height;
    }

    private int GetBalance(Node node) {
        return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
    }

    private Node RightRotate(Node y) {
        var x = y.Left;
        var T2 = x.Right;

        x.Right = y;
        y.Left = T2;

        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

        return x;
    }

    private Node LeftRotate(Node x) {
        var y = x.Right;
        var T2 = y.Left;

        y.Left = x;
        x.Right = T2;

        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

        return y;
    }

    private Node InsertNode(Node node, int position) {
        if (node == null) {
            return new Node(position);
        }

        if (position < node.Position) {
            node.Left = InsertNode(node.Left, position);
        } else if (position > node.Position) {
            node.Right = InsertNode(node.Right, position);
        } else {
            return node;
        }

        node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;

        int balance = GetBalance(node);

        if (balance > 1 && position < node.Left.Position) {
            return RightRotate(node);
        }

        if (balance < -1 && position > node.Right.Position) {
            return LeftRotate(node);
        }

        if (balance > 1 && position > node.Left.Position) {
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);
        }

        if (balance < -1 && position < node.Right.Position) {
            node.Right = RightRotate(node.Right);
            return LeftRotate(node);
        }

        return node;
    }

    private Node DeleteNode(Node node, int position) {
        if (node == null) {
            return node;
        }

        if (position < node.Position) {
            node.Left = DeleteNode(node.Left, position);
        } else if (position > node.Position) {
            node.Right = DeleteNode(node.Right, position);
        } else {
            if (node.Left == null) {
                return node.Right;
            } else if (node.Right == null) {
                return node.Left;
            }

            var successor = GetMinValueNode(node.Right);
            node.Position = successor.Position;
            node.Right = DeleteNode(node.Right, successor.Position);
        }

        if (node == null) {
            return node;
        }

        node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;

        int balance = GetBalance(node);

        if (balance > 1 && GetBalance(node.Left) >= 0) {
            return RightRotate(node);
        }

        if (balance > 1 && GetBalance(node.Left) < 0) {
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);
        }

        if (balance < -1 && GetBalance(node.Right) <= 0) {
            return LeftRotate(node);
        }

        if (balance < -1 && GetBalance(node.Right) > 0) {
            node.Right = RightRotate(node.Right);
            return LeftRotate(node);
        }

        return node;
    }

    private Node GetMinValueNode(Node node) {
        var current = node;
        while (current.Left != null) {
            current = current.Left;
        }
        return current;
    }

    private void UpdatePositions(Node node, int startPos, int shift) {
        if (node == null) {
            return;
        }

        if (node.Position >= startPos) {
            node.Position += shift;
        }

        UpdatePositions(node.Right, startPos, shift);

        if (node.Position >= startPos) {
            UpdatePositions(node.Left, startPos, shift);
        }
    }

    private int CountSmaller(Node node, int position) {
        if (node == null) {
            return 0;
        }

        if (position < node.Position) {
            return CountSmaller(node.Left, position);
        } else {
            return 1 + CountSmaller(node.Left, position) + CountSmaller(node.Right, position);
        }
    }
}