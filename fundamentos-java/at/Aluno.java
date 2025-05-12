import java.util.Scanner;

public class Aluno {
    private final String nome;
    private final String matricula;
    private final double[] notas;


    public Aluno(String nome, String matricula, double[] notas) {
        this.nome = nome;
        this.matricula = matricula;
        this.notas = notas;
    }

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        System.out.println("------- Gerenciamento de Alunos -------");

        System.out.print("Nome do aluno: ");
        String nome = input.nextLine();

        System.out.print("Matrícula: ");
        String matricula = input.nextLine();

        double[] notas = new double[3];
        // Loop para não repetir muito o codigo
        for (int i = 0; i < notas.length; i++) {
            System.out.printf("%d Digite sua nota: ", i + 1);
            notas[i] = input.nextDouble();
        }

        Aluno aluno = new Aluno(nome, matricula, notas);
        aluno.verificarAprovacao();

        input.close();
    }

    public double calcularMedia() {
        double media = 0;
        for (double nota : this.notas) {
            media += nota;
        }
        return media / this.notas.length;
    }


    public void verificarAprovacao() {
        double media = calcularMedia();

        System.out.printf("""
                        Aluno: %s\
                        
                        Matrícula: %s\
                        
                        Média: %.2f\
                        
                        """,
                this.nome, this.matricula, media);

        if (media < 7.0)
            System.out.println("Situação: [REPROVADO]");
        else
            System.out.println("Situação: [APROVADO]");
    }
}
