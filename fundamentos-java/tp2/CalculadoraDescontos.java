import java.util.Scanner;

public class CalculadoraDescontos {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        System.out.println("Valor da compra: ");
        double valorCompra = input.nextDouble();

        double descontoPorcentagem = 0;
        double valorDesconto = 0;

        // verificar o valor e aplicar o desconto
        if (valorCompra > 1000) {
            descontoPorcentagem = 0.10; // 10%
        } else if (valorCompra >= 500) {
            descontoPorcentagem = 0.05; // 5%
        }

        valorDesconto = valorCompra * descontoPorcentagem;
        double total = valorCompra - valorDesconto;

        System.out.println("Valor original: " + valorCompra
                + "\nDesconto: " + valorDesconto
                + "\nPorcentagem: " + (descontoPorcentagem * 100) + "%"
                + "\nTotal: " + total);

        input.close();
    }
}
