import java.util.Scanner;

public class ImpostoRenda {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        double FAIXA_1 = 25000;
        double FAIXA_2 = 40000;
        double FAIXA_3 = 72000;
        
        double alquiota_1 = 0.8;
        double alquiota_2 = 0.13;
        double alquiota_3 = 0.2;

        System.out.println("Salário Bruto Anual: R$ ");
        double salario = input.nextDouble();

        double totalImposto = 0;
        if (salario <= FAIXA_1) {
            totalImposto = 0;
        } else if (salario <= FAIXA_2) {
            totalImposto = salario * alquiota_1;
        } else if (salario <= FAIXA_3) {
            totalImposto = salario * alquiota_2;
        } else {
            totalImposto = salario * alquiota_3;
        }

        double liquido = salario - totalImposto;

        System.out.println("Salário Bruto Anual: R$ " + salario
                + "\nSalário Liquido Anual: R$ " + liquido
                + "\nTotal de Imposto: R$ " + totalImposto);

        input.close();
    }
}
