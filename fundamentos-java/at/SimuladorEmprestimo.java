import java.util.Scanner;

public class SimuladorEmprestimo {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        System.out.println("Nome do cliente: ");
        String cliente = input.nextLine();

        System.out.println("Valor do empréstimo: R$ ");
        double valorEmprestimo = input.nextDouble();

        int parcelas = 0;
        while (parcelas < 6 || parcelas > 48) {
            System.out.println("Número de parcelas (mínimo 6, máximo 48): ");
            parcelas = input.nextInt();

            if (parcelas < 6 || parcelas > 48)
                System.out.println("Valor inválido. Deve ser entre 6 e 48.");
        }

        double taxaJurosMensal = 0.03; // 3%
        double valorTotal = valorEmprestimo * Math.pow((1 + taxaJurosMensal), parcelas); // juros compostos
        double valorParcela = valorTotal / parcelas; // mensal

        System.out.printf("""
                        Cliente %s\
                        
                        Empréstimo total: R$ %.2f\
                        
                        Parcela mensal: R$ %.2f\
                        
                        """,
                cliente, valorTotal, valorParcela);

        input.close();
    }
}
