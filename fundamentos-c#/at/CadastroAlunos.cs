namespace at;

public class CadastroAlunos
{
    public static void Cadastrar() // usado no Main em Program.cs
    {
        Aluno novoAluno = new Aluno()
        {
            Nome = "Marcos Souza",
            Matricula = "2302084",
            Curso = "Enfermagem",
            MediaNotas = 6.7
        };

        novoAluno.ExibirDados();
    }
}

internal class Aluno
{
    public string Nome { get; set; }
    public string Matricula { get; set; }
    public string Curso { get; set; }
    public double MediaNotas { get; set; }

    public void ExibirDados()
    {
        Console.WriteLine("---- Dados do Aluno ----");
        Console.WriteLine("Nome: {0}" +
                          "\nMatrícula: {1}" +
                          "\nCurso: {2}" +
                          "\nMédia das Notas: {3:F2}" +
                          "\nSituação: {4}",
                          Nome, Matricula, Curso, MediaNotas, VerificarAprovacao());
    }

    private string VerificarAprovacao()
    {
        return MediaNotas >= 7 ? "Aprovado" : "Reprovado";
    }
}