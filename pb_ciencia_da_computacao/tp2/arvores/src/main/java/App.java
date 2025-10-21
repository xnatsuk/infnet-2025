public class App {
    public static void main(String[] args) {
        RedBlackTreeInt tree = new RedBlackTreeInt();

        System.out.println("=== INSERÇÕES: 41, 38, 31, 12, 19, 8 ===");
        int[] values = {41, 38, 31, 12, 19, 8};

        for (int val : values) {
            tree.insert(val);
        }

        System.out.print("Inorder: ");
        tree.inorder();

        System.out.println("Black Height: " + tree.blackHeight());

        System.out.println("\n=== REMOVENDO 12 ===");
        tree.delete(12);
        System.out.print("Inorder: ");
        tree.inorder();

        System.out.println("\n=== REMOVENDO 19 ===");
        tree.delete(19);
        System.out.print("Inorder: ");
        tree.inorder();

        System.out.println("Black Height: " + tree.blackHeight());
    }
}
