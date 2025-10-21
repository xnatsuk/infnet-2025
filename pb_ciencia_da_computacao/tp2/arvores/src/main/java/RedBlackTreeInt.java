public class RedBlackTreeInt {
    private Node root;
    private final Node NIL; // folhas nulas

    public RedBlackTreeInt() {
        NIL = new Node(0);
        NIL.color = Color.BLACK;
        root = NIL;
    }

    public void insert(int data) {
        Node node = new Node(data);
        node.left = node.right = NIL;

        Node parent = null;
        Node current = root;

        while (current != NIL) {
            parent = current;
            current = (node.data < current.data) ? current.left : current.right;
        }

        node.parent = parent;
        if (parent == null) root = node;
        else if (node.data < parent.data) parent.left = node;
        else parent.right = node;

        insertFixup(node);
    }

    // restaura as propriedades após uma inserção
    private void insertFixup(Node k) {
        while (k.parent != null && k.parent.color == Color.RED) {
            boolean isLeft = k.parent == k.parent.parent.left;
            Node uncle = isLeft ? k.parent.parent.right : k.parent.parent.left;

            if (uncle.color == Color.RED) {
                k.parent.color = uncle.color = Color.BLACK;
                k.parent.parent.color = Color.RED;
                k = k.parent.parent;
            } else {
                if (k == (isLeft ? k.parent.right : k.parent.left)) {
                    k = k.parent;
                    if (isLeft) leftRotate(k);
                    else rightRotate(k);
                }
                k.parent.color = Color.BLACK;
                k.parent.parent.color = Color.RED;
                if (isLeft) rightRotate(k.parent.parent);
                else leftRotate(k.parent.parent);
            }
        }
        root.color = Color.BLACK;
    }

    public void delete(int data) {
        Node z = root;
        while (z != NIL && data != z.data) {
            z = (data < z.data) ? z.left : z.right;
        }

        if (z == NIL) {
            System.out.println("Chave " + data + " não encontrada");
            return;
        }

        // deleta nó
        Node y = z;
        Color yOriginalColor = y.color;
        Node x;

        if (z.left == NIL) {
            x = z.right;
            transplant(z, z.right);
        } else if (z.right == NIL) {
            x = z.left;
            transplant(z, z.left);
        } else {
            // mínimo
            y = z.right;
            while (y.left != NIL) y = y.left;

            yOriginalColor = y.color;
            x = y.right;

            if (y.parent == z) {
                x.parent = y;
            } else {
                transplant(y, y.right);
                y.right = z.right;
                y.right.parent = y;
            }

            transplant(z, y);
            y.left = z.left;
            y.left.parent = y;
            y.color = z.color;
        }

        if (yOriginalColor == Color.BLACK) deleteFixup(x);
    }

    // restaura as propriedades após uma deleção
    private void deleteFixup(Node x) {
        while (x != root && x.color == Color.BLACK) {
            boolean isLeft = x == x.parent.left;
            Node w = isLeft ? x.parent.right : x.parent.left;

            if (w.color == Color.RED) {
                w.color = Color.BLACK;
                x.parent.color = Color.RED;
                if (isLeft) leftRotate(x.parent);
                else rightRotate(x.parent);
                w = isLeft ? x.parent.right : x.parent.left;
            }

            if ((isLeft ? w.left : w.right).color == Color.BLACK &&
                    (isLeft ? w.right : w.left).color == Color.BLACK) {
                w.color = Color.RED;
                x = x.parent;
            } else {
                if ((isLeft ? w.right : w.left).color == Color.BLACK) {
                    (isLeft ? w.left : w.right).color = Color.BLACK;
                    w.color = Color.RED;
                    if (isLeft) rightRotate(w);
                    else leftRotate(w);
                    w = isLeft ? x.parent.right : x.parent.left;
                }
                w.color = x.parent.color;
                x.parent.color = Color.BLACK;
                (isLeft ? w.right : w.left).color = Color.BLACK;
                if (isLeft) leftRotate(x.parent);
                else rightRotate(x.parent);
                x = root;
            }
        }
        x.color = Color.BLACK;
    }

    // method overloading (sobrecarga de métodos)
    public void inorder() {
        inorder(root);
        System.out.println();
    }

    private void inorder(Node node) {
        if (node != NIL) {
            inorder(node.left);
            System.out.print(node.data + " ");
            inorder(node.right);
        }
    }


    // altura da árvore
    public int blackHeight() {
        return blackHeight(root);
    }

    // altura de um nó específico
    public int blackHeight(int data) {
        Node node = root;
        while (node != NIL && data != node.data) {
            node = (data < node.data) ? node.left : node.right;
        }
        return (node == NIL) ? -1 : blackHeight(node);
    }

    // cálculo recursivo
    private int blackHeight(Node node) {
        if (node == NIL) return 1;
        int leftHeight = blackHeight(node.left);
        if (leftHeight == -1) return -1;
        int rightHeight = blackHeight(node.right);
        if (rightHeight == -1 || leftHeight != rightHeight) return -1;

        return leftHeight + (node.color == Color.BLACK ? 1 : 0);
    }


    // substitui subárvore enraizada por outra
    private void transplant(Node u, Node v) {
        if (u.parent == null) root = v;
        else if (u == u.parent.left) u.parent.left = v;
        else u.parent.right = v;
        v.parent = u.parent;
    }

    private void leftRotate(Node x) {
        Node y = x.right;
        x.right = y.left;
        if (y.left != NIL) y.left.parent = x;
        y.parent = x.parent;
        if (x.parent == null) root = y;
        else if (x == x.parent.left) x.parent.left = y;
        else x.parent.right = y;
        y.left = x;
        x.parent = y;
    }

    private void rightRotate(Node x) {
        Node y = x.left;
        x.left = y.right;
        if (y.right != NIL) y.right.parent = x;
        y.parent = x.parent;
        if (x.parent == null) root = y;
        else if (x == x.parent.right) x.parent.right = y;
        else x.parent.left = y;
        y.right = x;
        x.parent = y;
    }
}
