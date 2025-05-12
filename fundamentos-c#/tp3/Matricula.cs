namespace tp3;

public class Matricula
{
    public string curso;
    public string dataInicial;
    public string nomeDoAluno;
    public int numeroMatricula;
    public string situacao;

    public void Trancar()
    {
        situacao = "Trancada";
    }

    public void Reativar()
    {
        situacao = "Ativa";
    }

    public void ExibirInformacoes()
    {
        Console.WriteLine("Aluno: {0} \nCurso: {1} \nNúmero de Matrícula: {2} \nSituacao: {3} \nData Inicial: {4}",
                          nomeDoAluno, curso, numeroMatricula, situacao, dataInicial);
    }
}