import java.util.Scanner;

public class CalculadoraNotas {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        // Considerei double usando virgula ao inves de ponto.
        // Ex.: 6,8
        double[] notas = new double[4];
        // Loop para não repetir muito o codigo
        for (int i = 0; i < notas.length; i++) {
            System.out.printf("%d Digite sua nota: ", i + 1);
            notas[i] = input.nextDouble();
        }

        double media = calcularMedia(notas);
        System.out.println("Média de notas: " + media);

        if (media >= 7) {
            System.out.println("[Aprovado]");
        } else if (media >= 5) {
            System.out.println("[Recuperação]");
        } else {
            System.out.println("[Reprovado]");
        }

        input.close();
    }

    public static double calcularMedia(double[] notas) {
        double media = 0;
        for (double nota : notas) {
            media += nota;
        }
        return media / notas.length;
    }
}
