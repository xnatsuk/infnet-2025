import java.util.Scanner;

public class AnoBissexto {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        System.out.println("Ano: ");
        int ano = input.nextInt();

        // Divisivel por 4 e por 100;
        // Divisivel por 400;
        boolean isBissexto = ano % 4 == 0 && ano % 100 != 0 || ano % 400 == 0;
        if (isBissexto) {
            System.out.println(ano + " é bissexto.");
        } else {
            System.out.println(ano + " não é bissexto.");
        }
    }
}
