namespace at;

public class At
{
    private static void Main(string[] args)
    {
        // Run(Program.MainProgram);
        // Run(Cifrador.CifradorNome);
        // Run(Calculadora.Calcular);
        // Run(DiasAniversario.Contar);
        // Run(DataFormatura.Calcular);
        // Run(CadastroAlunos.Cadastrar);
        // Run(Banco.Testar);
        // Run(FuncionarioTeste.Salario);
        // Run(ControleEstoque.Testar);
        // Run(Adivinha.Jogar);
        Run(GerenciadorContatos.Testar);
    }

    private static void Run(Action action)
    {
        Console.Clear();

        try
        {
            action();
        }
        catch (Exception e)
        {
            Console.WriteLine("[Erro ao executar o exercício] \n{0}", e.Message);
        }
    }
}