class TestaConta {
    public static void main(String[] args) {
        Conta conta = new Conta("Paulo Coelho", 12345, "0001", 12000, "15/03/2025");

        // informações iniciais
        System.out.println("Titular: " + conta.titular);
        System.out.println("Número: " + conta.numero);
        System.out.println("Agência: " + conta.agencia);
        System.out.println("Saldo inicial: R$ " + conta.saldo);
        System.out.println("Data de abertura: " + conta.dataAbertura);


        double deposito = 500.0;
        System.out.println("\nDepositando R$ " + deposito);
        conta.deposita(deposito);
        System.out.println("Saldo: R$ " + conta.saldo);

        double saque = 300.0;
        System.out.println("\nSacando R$ " + saque);
        conta.saca(saque);
        System.out.println("Saldo: R$ " + conta.saldo);

        double rendimento = conta.calculaRendimento();
        System.out.println("\nRendimento mensal: R$ " + rendimento);
    }
}

class Conta {
    String titular;
    int numero;
    String agencia;
    double saldo;
    String dataAbertura;

    Conta(String titular, int numero, String agencia, double saldo, String dataAbertura) {
        this.titular = titular;
        this.numero = numero;
        this.agencia = agencia;
        this.saldo = saldo;
        this.dataAbertura = dataAbertura;
    }

    void saca(double valor) {
        saldo -= valor;
    }

    void deposita(double valor) {
        saldo += valor;
    }

    double calculaRendimento() {
        return saldo * 0.15;
    }
}
