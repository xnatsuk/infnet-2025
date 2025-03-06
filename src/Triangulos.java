import java.util.Scanner;

public class Triangulos {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        System.out.println("Comprimento do primeiro lado: ");
        double a = input.nextDouble();
        System.out.println("Comprimento do segundo lado: ");
        double b = input.nextDouble();
        System.out.println("Comprimento do terceiro lado: ");
        double c = input.nextDouble();

//        soma de dois lados é maior que o terceiro
        boolean valido = a + b > c &&
                a + c > b &&
                b + c > a;

        if (valido) {
            if (a == b && b == c) {
                System.out.println("Triângulo Equilátero");
            } else if (a == b || a == c || b == c) {
                System.out.println("Triângulo Isósceles");
            } else {
                System.out.println("Triângulo Escaleno");
            }
        } else {
            System.out.println("O Triângulo é inválido.");
        }

        input.close();
    }
}
