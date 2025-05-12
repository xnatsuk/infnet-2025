import java.util.Scanner;

public class ConversorMoeda {
    // Valores fixos
    static final double TAXA_DOLAR = 6.1;
    static final double TAXA_EURO = 6.8;
    static final double TAXA_LIBRA = 7.4;

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        System.out.println("Digite o valor em reais: ");
        double reais = input.nextDouble();
        input.nextLine();

        System.out.println("Deseja converter em (dolar | euro | libra)? ");
        String moeda = input.nextLine().toLowerCase();

        double valorConvertido = converter(reais, moeda);
        System.out.printf("Valor: %.2f", valorConvertido);

        input.close();
    }

    public static double converter(double valorReais, String moeda) {
        return switch (moeda) {
            case "dolar" -> valorReais / TAXA_DOLAR;
            case "euro" -> valorReais / TAXA_EURO;
            case "libra" -> valorReais / TAXA_LIBRA;
            default -> 0;
        };
    }
}
