namespace at;

public class Banco
{
    public static void Testar()
    {
        Conta conta = new Conta()
        {
            Titular = "Marcos Souza"
        };

        Console.WriteLine("Titular: {0}", conta.Titular);

        // transações
        conta.Depositar(30000);
        conta.ExibirSaldo();

        conta.Sacar(55000);
        conta.Sacar(12550);
        conta.ExibirSaldo();
    }
}

internal class Conta
{
    public string Titular { get; set; }
    private decimal _saldo { get; set; }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor do depósito deve ser positivo!");
            return;
        }

        _saldo += valor;
        Console.WriteLine("Depósito de {0:F2} realizado com sucesso!", valor);
    }

    public void Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor deve ser positivo!");
            return;
        }

        if (valor > _saldo)
        {
            Console.WriteLine("Saldo insuficiente para realizar o saque!");
            return;
        }

        _saldo -= valor;
        Console.WriteLine("Saque de {0:F2} realizado com sucesso!", valor);
    }

    public void ExibirSaldo()
    {
        Console.WriteLine("Saldo atual: R$ {0:F2}", _saldo);
    }
}