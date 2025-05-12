namespace tp2;

public class ParImpar
{
    public static void Verificar()
    {
        Console.Write("Digite um valor inteiro: ");
        if (!double.TryParse(Console.ReadLine(), out double valor)) Console.WriteLine("Valor inválido.");

        string resposta = valor % 2 == 0 ? "par" : "impar";

        Console.WriteLine("O número {0} é {1}", valor, resposta);
    }
}