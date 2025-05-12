import java.util.Scanner;

public class SequenciaNumerica {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        System.out.println("Valor inicial: ");
        int inicio = input.nextInt();

        System.out.println("Incremento: ");
        int incremento = input.nextInt();

        for (int i = inicio; i <= 100; i += incremento) {
            System.out.println(i);
        }

        input.close();
    }
}
