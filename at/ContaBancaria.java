import java.util.Scanner;

public class ContaBancaria {
    String titular;
    private double saldo;

    public ContaBancaria(String titular, double saldoInicial) {
        this.titular = titular;
        this.saldo = saldoInicial;
    }

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        System.out.print("Titular da conta: ");
        String titular = input.nextLine();

        System.out.print("Saldo inicial: R$ ");
        double saldoInicial = input.nextDouble();

        ContaBancaria conta = new ContaBancaria(titular, saldoInicial);
        int opcao = 0;

        while (opcao != 4) {
            System.out.println("""
                    \n------ Operações ------\
                    
                    1. Depositar\
                    
                    2. Sacar\
                    
                    3. Exibir Saldo\
                    
                    4. Sair\
                    
                    """);

            System.out.print("Escolha uma opção: ");
            opcao = input.nextInt();

            switch (opcao) {
                case 1:
                    System.out.print("Valor do depósito: R$ ");
                    double valorDeposito = input.nextDouble();
                    conta.depositar(valorDeposito);
                    break;
                case 2:
                    System.out.print("Valor do saque: R$ ");
                    double valorSaque = input.nextDouble();
                    conta.sacar(valorSaque);
                    break;
                case 3:
                    conta.exibirSaldo();
                    break;
                case 4:
                    System.out.println("Saindo...");
                    break;
                default:
                    System.out.println("Opção inválida.");
            }
        }

        input.close();
    }

    public void depositar(double valor) {
        if (valor > 0) {
            saldo += valor;
            System.out.println("Depósito realizado com sucesso.");
        } else {
            System.out.println("Erro: O valor de depósito deve ser positivo.");
        }
    }

    public void sacar(double valor) {
        if (saldo >= valor) {
            saldo -= valor;
            System.out.println("Saque realizado com sucesso.");
        } else {
            System.out.println("Erro: Saldo insuficiente.");
        }
    }

    public void exibirSaldo() {
        System.out.printf("""
                        \nTitular: %s\
                        
                        Saldo atual: R$ %.2f\
                        
                        """,
                this.titular, this.saldo);
    }
}
