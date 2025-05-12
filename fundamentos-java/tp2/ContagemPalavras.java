import java.util.Scanner;

public class ContagemPalavras {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        System.out.println("Frase: ");
        String frase = input.nextLine();

        String[] palavras = frase.split(" ");
        int total = 0;

        for (String palavra : palavras) {
            if (!palavra.isEmpty())
                total++;
            System.out.println("Palavra: " + palavra);
        }

        System.out.println("Total: " + total);
        input.close();
    }
}
