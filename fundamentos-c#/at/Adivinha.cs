namespace at;

public class Adivinha
{
    public static void Jogar()
    {
        Random random = new Random();
        int numeroSecreto = random.Next(1, 50);
        int tentativas = 5;
        bool acertou = false;

        Console.WriteLine("--- JOGO DE ADIVINHAÇÃO ---");
        Console.WriteLine("Tente adivinhar o número secreto entre 1 e 50.");

        while (tentativas > 0 && !acertou)
        {
            Console.WriteLine($"\nTentativas restantes: {tentativas}");
            Console.Write("Palpite: ");

            try
            {
                Int32.TryParse(Console.ReadLine(), out int palpite);

                if (palpite is < 1 or > 50)
                {
                    Console.WriteLine("O número deve estar entre 1 e 50");
                    continue;
                }

                tentativas--;

                if (palpite == numeroSecreto)
                {
                    acertou = true;
                    Console.WriteLine("\nParabéns! Você acertou o número secreto: {0}", numeroSecreto);
                    return;
                }

                string dica = palpite < numeroSecreto ? "maior" : "menor";
                Console.WriteLine("Tente um número {0}.", dica);
            }
            catch (Exception err)
            {
                Console.WriteLine($"Erro: {err.Message}");
            }
        }

        // acabaram as tentativas e não acertou
        if (!acertou)
            Console.WriteLine("\nSuas tentativas acabaram! O número secreto era: {0}", numeroSecreto);

        Console.WriteLine("\nFim do jogo.");
    }
}