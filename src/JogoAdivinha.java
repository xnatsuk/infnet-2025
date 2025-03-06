import java.util.Random;
import java.util.Scanner;

public class JogoAdivinha {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        Random aleatorio = new Random();

        int segredo = aleatorio.nextInt(100) + 1;
        int numero;
        do {
            System.out.println("Adivinhe o número: ");
            numero = input.nextInt();

            if (numero < segredo) {
                System.out.println("Menor que o número sorteado.");
            } else if (numero > segredo) {
                System.out.println("Maior que o número sorteado.");
            }
        } while (numero != segredo);

        System.out.println("Você acertou!");
        input.close();
    }
}
