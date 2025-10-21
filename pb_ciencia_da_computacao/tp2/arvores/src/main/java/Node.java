public class Node {
    int data;
    Node left, right, parent;
    Color color;

    public Node(int data) {
        this.data = data;
        this.color = Color.RED;
    }
}
