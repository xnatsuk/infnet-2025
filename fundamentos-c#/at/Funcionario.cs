namespace at;

public class FuncionarioTeste()
{
    public static void Salario()
    {
        Funcionario funcionario = new Funcionario()
        {
            Nome = "Rodrigo Rodrigues",
            Cargo = "Analista de Sistemas",
            SalarioBase = 12000
        };

        Gerente gerente = new Gerente()
        {
            Nome = "Ana Paula",
            Cargo = "Gerente",
            SalarioBase = 15200
        };

        Console.WriteLine("Salário do Funcionário: R$ {0:F2} \nSalário de Gerente: R$ {1:F2}",
                          funcionario.SalarioBase, gerente.CalculoSalario());
    }
}

public class Funcionario
{
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public decimal SalarioBase { get; set; }
}

internal class Gerente : Funcionario
{
    public decimal CalculoSalario()
    {
        return SalarioBase * 1.2m; // 20% de bonus
    }
}