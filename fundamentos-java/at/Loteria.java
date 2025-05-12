import java.util.*;

public class Loteria {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        Random random = new Random();

        System.out.println("----- Loteria -----");

        // Garante que os números sejam únicos
        SortedSet<Integer> sorteados = new TreeSet<>();
        while (sorteados.size() < 6) {
            int numero = random.nextInt(60) + 1;
            sorteados.add(numero);
        }

        SortedSet<Integer> palpite = new TreeSet<>();
        System.out.println("Digite 6 números entre 1 e 60:");

        while (palpite.size() < 6) {
            System.out.printf("Número %d: ", palpite.size() + 1);
            try {
                int numero = input.nextInt();

                if (numero < 1 || numero > 60) {
                    System.out.println("Erro: Digite um número entre 1 e 60.");
                    continue;
                }

                if (palpite.contains(numero)) {
                    System.out.println("Erro: Você já escolheu este número.");
                    continue;
                }

                palpite.add(numero);

            } catch (Exception e) {
                System.out.printf(e.getMessage());
                input.nextLine(); // Limpa o buffer
            }
        }

        Set<Integer> acertos = new HashSet<>(palpite);
        acertos.retainAll(sorteados); // Apenas os números em comum

        System.out.println("\n----- Resultado do Sorteio -----");
        System.out.print("Sorteados: ");
        for (int numero : sorteados) {
            System.out.printf("%02d ", numero);
        }

        System.out.print("\nSeus números: ");
        for (int numero : palpite) {
            System.out.printf("%02d ", numero);
        }

        if (acertos.isEmpty()) {
            System.out.println("\nNão houve nenhum acerto.");
            return;
        }

        System.out.println("\nTotal de acertos: " + acertos.size());

        input.close();
    }
}
