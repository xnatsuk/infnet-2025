import java.util.Scanner;

public class CalculadoraImpostos {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        double FAIXA_1 = 22847.76;
        double FAIXA_2 = 33919.80;
        double FAIXA_3 = 45012.60;

        double alquiota_1 = 0.075;
        double alquiota_2 = 0.15;
        double alquiota_3 = 0.275;

        System.out.print("Digite seu nome: ");
        String nome = input.nextLine();

        System.out.print("Digite seu salário mensal: R$ ");
        double salarioMensal = input.nextDouble();

        double salarioAnual = salarioMensal * 12;
        double valorImposto = 0;

        if (salarioAnual <= FAIXA_1) {
            valorImposto = 0;
        } else if (salarioAnual <= FAIXA_2) {
            valorImposto = salarioAnual * alquiota_1;
        } else if (salarioAnual <= FAIXA_3) {
            valorImposto = salarioAnual * alquiota_2;
        } else {
            valorImposto = salarioAnual * alquiota_3;
        }
        double salarioLiquido = salarioAnual - valorImposto;

        System.out.printf("""
                        Valor do Imposto: R$ %.2f\
                        
                        Salário líquido: R$ %.2f\
                        
                        """,
                valorImposto, salarioLiquido);

        input.close();
    }
}
