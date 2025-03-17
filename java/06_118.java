public class RedBlackTree {
    private static final boolean RED = true;
    private static final boolean BLACK = false;

    private class Node {
        int key;
        Node left, right, parent;
        boolean color; // true for red, false for black

        Node(int key) {
            this.key = key;
            this.color = RED;
            this.left = NIL;
            this.right = NIL;
        }
    }

    private final Node NIL;
    private Node root;

    public RedBlackTree() {
        NIL = new Node(0);
        NIL.color = BLACK;
        root = NIL;
    }

    public void insert(int key) {
        Node node = new Node(key);

        Node y = NIL;
        Node x = root;

        // Find position for new node
        while (x != NIL) {
            y = x;
            if (node.key < x.key) {
                x = x.left;
            } else {
                x = x.right;
            }
        }

        // Set parent of node
        node.parent = y;

        // If tree is empty, make node the root
        if (y == NIL) {
            root = node;
        } else if (node.key < y.key) {
            y.left = node;
        } else {
            y.right = node;
        }

        // Fix the tree
        fixInsert(node);
    }

    private void fixInsert(Node k) {
        Node uncle;

        // While parent is red
        while (k.parent != NIL && k.parent.color == RED) {
            if (k.parent == k.parent.parent.right) {
                uncle = k.parent.parent.left;

                // Case 1: Uncle is red
                if (uncle.color == RED) {
                    uncle.color = BLACK;
                    k.parent.color = BLACK;
                    k.parent.parent.color = RED;
                    k = k.parent.parent;
                } else {
                    // Case 2: Uncle is black and k is left child
                    if (k == k.parent.left) {
                        k = k.parent;
                        rightRotate(k);
                    }

                    // Case 3: Uncle is black and k is right child
                    k.parent.color = BLACK;
                    k.parent.parent.color = RED;
                    leftRotate(k.parent.parent);
                }
            } else {
                uncle = k.parent.parent.right;

                // Case 1: Uncle is red
                if (uncle.color == RED) {
                    uncle.color = BLACK;
                    k.parent.color = BLACK;
                    k.parent.parent.color = RED;
                    k = k.parent.parent;
                } else {
                    // Case 2: Uncle is black and k is right child
                    if (k == k.parent.right) {
                        k = k.parent;
                        leftRotate(k);
                    }

                    // Case 3: Uncle is black and k is left child
                    k.parent.color = BLACK;
                    k.parent.parent.color = RED;
                    rightRotate(k.parent.parent);
                }
            }

            if (k == root) {
                break;
            }
        }
        root.color = BLACK;
    }

    private void leftRotate(Node x) {
        Node y = x.right;
        x.right = y.left;

        if (y.left != NIL) {
            y.left.parent = x;
        }

        y.parent = x.parent;

        if (x.parent == NIL) {
            root = y;
        } else if (x == x.parent.left) {
            x.parent.left = y;
        } else {
            x.parent.right = y;
        }

        y.left = x;
        x.parent = y;
    }

    private void rightRotate(Node x) {
        Node y = x.left;
        x.left = y.right;

        if (y.right != NIL) {
            y.right.parent = x;
        }

        y.parent = x.parent;

        if (x.parent == NIL) {
            root = y;
        } else if (x == x.parent.right) {
            x.parent.right = y;
        } else {
            x.parent.left = y;
        }

        y.right = x;
        x.parent = y;
    }

    public Node search(int key) {
        return searchHelper(root, key);
    }

    private Node searchHelper(Node node, int key) {
        if (node == NIL || key == node.key) {
            return node;
        }

        if (key < node.key) {
            return searchHelper(node.left, key);
        }
        return searchHelper(node.right, key);
    }

    public void inOrderTraversal() {
        System.out.println("In-order traversal of the Red-Black Tree:");
        inOrderHelper(root);
        System.out.println();
    }

    private void inOrderHelper(Node node) {
        if (node != NIL) {
            inOrderHelper(node.left);
            System.out.print(node.key + "(" + 
                            (node.color ? "RED" : "BLACK") + ") ");
            inOrderHelper(node.right);
        }
    }

    public static void main(String[] args) {
        RedBlackTree rbTree = new RedBlackTree();
        int[] keys = {7, 3, 18, 10, 22, 8, 11, 26};

        for (int key : keys) {
            rbTree.insert(key);
        }

        rbTree.inOrderTraversal();

        int keyToFind = 10;
        Node foundNode = rbTree.search(keyToFind);
        if (foundNode != rbTree.NIL) {
            System.out.println("Found key " + keyToFind + 
                              ", color: " + 
                              (foundNode.color ? "RED" : "BLACK"));
        } else {
            System.out.println("Key " + keyToFind + " not found");
        }
    }
}